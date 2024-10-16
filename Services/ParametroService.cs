using AutoMapper;
using RetoTecnico.DTOs;
using RetoTecnico.Models;
using RetoTecnico.Repository;
using FluentValidation;
using FluentValidation.AspNetCore;

namespace RetoTecnico.Services
{
    public class ParametroService : ICommonService<ParametroDto, ParametroInsertDto, ParametroUpdateDto>
    {
        private IRepository<Parametros> _parametrosRepository;
         private IMapper _mapper;
        public List<string> Errors {get;}
        public ParametroService(IRepository<Parametros> ParametrosRepository, IMapper mapper){
            _parametrosRepository = ParametrosRepository;
            _mapper = mapper;
            Errors = new List<string>();
        }
         public async Task<IEnumerable<ParametroDto>> Get()
         {
            var Parametross = await _parametrosRepository.Get();
            return Parametross.Select(c => _mapper.Map<ParametroDto>(c));
         }
         
         public async Task<ParametroDto> GetById(int id)
         {
            var Parametros = await _parametrosRepository.GetById(id);

            if (Parametros != null)
            {
                var ParametroDto = _mapper.Map<ParametroDto>(Parametros);

                return ParametroDto;
            }
            return null;
         }

         public async Task<ParametroDto> Add(ParametroInsertDto ParametroInsertDto){
            var Parametros = _mapper.Map<Parametros>(ParametroInsertDto);
            await _parametrosRepository.Add(Parametros);
            await _parametrosRepository.Save();
            var parametroDto = _mapper.Map<ParametroDto>(Parametros);
            return parametroDto;
         } 

         public async Task<ParametroDto> Update(int id, ParametroUpdateDto ParametroUpdateDto){
            var Parametros = await _parametrosRepository.GetById(id);

            if(Parametros != null)
            {
                Parametros = _mapper.Map(ParametroUpdateDto, Parametros); // Mapea directamente
                
                _parametrosRepository.Update(Parametros);
                await _parametrosRepository.Save();

                var ParametroDto = _mapper.Map<ParametroDto>(Parametros);

                return ParametroDto;
            }
            //Si no encontramos o cualquier error regresamos null y el controlador se encarga de manejar excepciones
            return null;
         }

         public async Task<ParametroDto> Delete(int id){
            var Parametros = await _parametrosRepository.GetById(id);

             if (Parametros != null)
            {
                //Se llena la información antes de que se elimine
                var ParametroDto = _mapper.Map<ParametroDto>(Parametros);

                _parametrosRepository.Delete(Parametros);
                await _parametrosRepository.Save();

                return ParametroDto;
            }
            return null;
         }

         public bool Validate(ParametroInsertDto ParametroInsertDto)
         {
            return false;
         }

         public bool Validate(ParametroUpdateDto ParametroUpdateDto)
        {
            return true;
        }
    }
}