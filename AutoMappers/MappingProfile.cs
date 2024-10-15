
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
        }
    }
}