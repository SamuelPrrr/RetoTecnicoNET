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

         private IMapper _mapper;
        public List<string> Errors {get;}
        public AlhajaService(IRepository<Alhaja> alhajaRepository, IMapper mapper, IRepository<Cliente> clienteRepository){
            _alhajaRepository = alhajaRepository;
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

                // Asignar valores calculados
                /* alhaja.PrecioGramo = parametros.PrecioOroGramo;
                alhaja.Interes = parametros.PorcentajeInteres;
                alhaja.MontoEmpeño = alhaja.PesoKG * alhaja.PrecioGramo;
                alhaja.MontoInteres = alhaja.MontoEmpeño * (alhaja.Interes / 100);
                alhaja.MontoDeuda = alhaja.MontoEmpeño + alhaja.MontoInteres;

                // Fecha de operación y vencimiento
                alhaja.FechaOperacion = DateTime.Now;
                alhaja.FechaVencimiento = alhaja.FechaOperacion.AddMonths(1); */

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
            return true;
        }

    }
}