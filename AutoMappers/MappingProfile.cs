
using AutoMapper;
using RetoTecnico.DTOs;
using RetoTecnico.Models;
using Microsoft.JSInterop;
 
namespace RetoTecnico.Automappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
        // Mapeos para Cliente, Primero va el origen y luego el destino
        CreateMap<Cliente, ClienteDto>().ReverseMap();
        CreateMap<Cliente, ClienteInsertDto>().ReverseMap();
        CreateMap<Cliente, ClienteUpdateDto>().ReverseMap();

        //Para la alhaja
        CreateMap<Alhaja, AlhajaDto>().ReverseMap();
        CreateMap<Alhaja, AlhajaInsertDto>().ReverseMap();
        CreateMap<Alhaja, AlhajaUpdateDto>().ReverseMap();

        //Parametro
        CreateMap<Parametros, ParametroDto>().ReverseMap();
        CreateMap<Parametros, ParametroInsertDto>().ReverseMap();
        CreateMap<Parametros, ParametroUpdateDto>().ReverseMap();
        }
    }
}