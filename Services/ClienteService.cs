using AutoMapper;
using RetoTecnico.DTOs;
using RetoTecnico.Models;
using RetoTecnico.Repository;
using FluentValidation;
using FluentValidation.AspNetCore;

namespace RetoTecnico.Services
{
    public class ClienteService : ICommonService<ClienteDto, ClienteInsertDto, ClienteUpdateDto>
    {
        private IRepository<Cliente> _clienteRepository;
         private IMapper _mapper;
        public List<string> Errors {get;}
        public ClienteService(IRepository<Cliente> clienteRepository, IMapper mapper){
            _clienteRepository = clienteRepository;
            _mapper = mapper;
            Errors = new List<string>();
        }
         public async Task<IEnumerable<ClienteDto>> Get()
         {
            var clientes = await _clienteRepository.Get();
            return clientes.Select(c => _mapper.Map<ClienteDto>(c));
         }
         
         public async Task<ClienteDto> GetById(int id)
         {
            var cliente = await _clienteRepository.GetById(id);

            if (cliente != null)
            {
                var clienteDto = _mapper.Map<ClienteDto>(cliente);

                return clienteDto;
            }
            return null;
         }

         public async Task<ClienteDto> Add(ClienteInsertDto clienteInsertDto){
            var cliente = _mapper.Map<Cliente>(clienteInsertDto);
            await _clienteRepository.Add(cliente);
            await _clienteRepository.Save();
            var beerDto = _mapper.Map<ClienteDto>(cliente);
            return beerDto;
         } 

         public async Task<ClienteDto> Update(int id, ClienteUpdateDto clienteUpdateDto){
            var cliente = await _clienteRepository.GetById(id);

            if(cliente != null)
            {
                cliente = _mapper.Map(clienteUpdateDto, cliente); // Mapea directamente
                
                _clienteRepository.Update(cliente);
                await _clienteRepository.Save();

                var ClienteDto = _mapper.Map<ClienteDto>(cliente);

                return ClienteDto;
            }
            //Si no encontramos o cualquier error regresamos null y el controlador se encarga de manejar excepciones
            return null;
         }

         public async Task<ClienteDto> Delete(int id){
            var Cliente = await _clienteRepository.GetById(id);

             if (Cliente != null)
            {
                //Se llena la información antes de que se elimine
                var ClienteDto = _mapper.Map<ClienteDto>(Cliente);

                _clienteRepository.Delete(Cliente);
                await _clienteRepository.Save();

                return ClienteDto;
            }
            return null;
         }

         public bool Validate(ClienteInsertDto clienteInsertDto)
         {
            return false;
         }

         public bool Validate(ClienteUpdateDto clienteUpdateDto)
        {
            return true;
        }
    }
}