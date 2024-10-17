using AutoMapper;
using RetoTecnico.DTOs;
using RetoTecnico.Models;
using RetoTecnico.Repository;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace RetoTecnico.Services
{
    public class AlhajaService : ICommonService<AlhajaDto, AlhajaInsertDto, AlhajaUpdateDto>
    {
        private IRepository<Alhaja> _alhajaRepository;
        private IRepository<Parametros> _parametroRepository;

         private IMapper _mapper;
        public List<string> Errors {get;}
        public AlhajaService(IRepository<Alhaja> alhajaRepository, IMapper mapper, IRepository<Parametros> parametroRepository){
            _alhajaRepository = alhajaRepository;
            _parametroRepository = parametroRepository;
            _mapper = mapper;
            Errors = new List<string>();
        }
         public async Task<IEnumerable<AlhajaDto>> Get()
         {
            var alhajas = await _alhajaRepository.Get();
            return alhajas.Select(a => _mapper.Map<AlhajaDto>(a));
         }
         
         public async Task<AlhajaDto> GetById(int id)
         {
            var alhaja = await _alhajaRepository.GetById(id);

            if (alhaja != null)
            {
                var alhajaDto = _mapper.Map<AlhajaDto>(alhaja);

                return alhajaDto;
            }
            return null;
         }

         public async Task<AlhajaDto> Add(AlhajaInsertDto alhajaInsertDto){
                var alhaja = _mapper.Map<Alhaja>(alhajaInsertDto);
                var parametros = await _parametroRepository.GetById(1);
                alhaja.PreOroMomento = parametros.PrecioGramo;
                alhaja.PorInteresMomento = parametros.Interes;
                alhaja.MontoEmpeño = alhaja.PesoKG * alhaja.PreOroMomento;
                alhaja.MontoInteres = alhaja.MontoEmpeño * (alhaja.PorInteresMomento / 100);
                alhaja.MontoDeuda = alhaja.MontoEmpeño + alhaja.MontoInteres;
                alhaja.FechaOperacion = DateTime.Now;
                alhaja.FechaVencimiento = alhaja.FechaOperacion.AddMonths(1);
                alhaja.IdEstatus = alhajaInsertDto.IdEstatus = 1;
                await _alhajaRepository.Add(alhaja);
                await _alhajaRepository.Save();
                var alhajaDto = _mapper.Map<AlhajaDto>(alhaja);
                return alhajaDto;
         } 

         public async Task<AlhajaDto> Update(int id, AlhajaUpdateDto alhajaUpdateDto){
            var alhaja = await _alhajaRepository.GetById(id);

            if(alhaja != null)
            {
                alhaja = _mapper.Map(alhajaUpdateDto, alhaja); // Mapea directamente
                
                _alhajaRepository.Update(alhaja);
                await _alhajaRepository.Save();

                var AlhajaDto = _mapper.Map<AlhajaDto>(alhaja);

                return AlhajaDto;
            }
            //Si no encontramos o cualquier error regresamos null y el controlador se encarga de manejar excepciones
            return null;
         }

         public async Task<AlhajaDto> Delete(int id){
            var alhaja = await _alhajaRepository.GetById(id);

             if (alhaja != null)
            {
                //Se llena la información antes de que se elimine
                var alhajaDto = _mapper.Map<AlhajaDto>(alhaja);

                _alhajaRepository.Delete(alhaja);
                await _alhajaRepository.Save();

                return alhajaDto;
            }
            return null;
         }

        public bool Validate(AlhajaInsertDto alhajaInsertDto)
        {
            
            return true;
        }

        public bool Validate(AlhajaUpdateDto alhajaUpdateDto)
        {
             // Buscar todas las alhajas que coincidan con la regla de negocio que necesitas
            var alhaja = _alhajaRepository.Search(a => a.AlhajaID == alhajaUpdateDto.AlhajaID).FirstOrDefault();

            // Si no se encuentra la alhaja, consideramos que no es válida
            if (alhaja == null)
            {
                Errors.Add("El empeño no existe no existe");
                return false;
            }

            var fechaLiquidacionValida = FechaLiquidacionEsValida(alhaja.FechaVencimiento, alhajaUpdateDto.FechaLiquidacion, alhajaUpdateDto.IdEstatus);
            if(!fechaLiquidacionValida)
            {
                Errors.Add("El empeño ha superado su fecha de vencimiento o ya ha sido cancelado y no puede ser liquidado.");
                return false;
            }

            var fechaCancelacionValida = FechaCancelacionEsValida(alhaja.FechaOperacion, alhajaUpdateDto.FechaLiquidacion, alhajaUpdateDto.IdEstatus);
            if(!fechaCancelacionValida)
            {
                Errors.Add("El empeño solo puede ser cancelado el mismo día de la operación.");
                return false;
            }

            return true;
        }

        private bool FechaLiquidacionEsValida(DateTime? fechaVencimiento, DateTime? fechaLiquidacion, int estatusId)
        {
        // Si el estatus es "Activo" (2)
        if (estatusId == 2)
        {
            // Verificar que no esté liquidado (3) ni cancelado (4), y que la fecha de liquidación sea válida
            return estatusId != 3 /* liquidado */ 
            && estatusId != 4 /* cancelado */ 
            && fechaLiquidacion.HasValue
            && fechaLiquidacion.Value <= fechaVencimiento;
        }
        return true; // Si no es "activo", no se aplica ninguna regla específica
        }

        private bool FechaCancelacionEsValida(DateTime? fechaOperacion, DateTime? fechaLiquidacion, int estatusId)
        {
            // Si el estatus es "cancelado", permitir solo si la cancelación ocurre el mismo día de la operación.
        if (estatusId == 4) // 4 significa "cancelado"
        {
            return fechaLiquidacion.Value.Date == fechaOperacion.Value.Date;
        };
        return true;
        }


        








    }
}