using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RetoTecnico.Services;
using RetoTecnico.DTOs;
using RetoTecnico.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Diagnostics;
using FluentValidation;



namespace RetoTecnico.Controllers
{   
    //[controller] define el nombre del controlador pero sin controller, como que estamos eliminando esa
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        
         private ICommonService<ClienteDto,ClienteInsertDto,ClienteUpdateDto> _clienteService;
         //Validador
         private IValidator<ClienteInsertDto> _clienteInsertValidator;

         private IValidator<ClienteUpdateDto> _ClienteUpdateDto;
         public ClienteController(IValidator<ClienteInsertDto> clienteInsertValidator, IValidator<ClienteUpdateDto> clienteUpdateDto,
            ICommonService<ClienteDto, ClienteInsertDto, ClienteUpdateDto> clienteService)
         {
            _clienteInsertValidator = clienteInsertValidator;
            _ClienteUpdateDto = clienteUpdateDto;
            _clienteService = clienteService;
         }

        [HttpGet]            
         public async Task<IEnumerable<ClienteDto>> Get() => 
            await _clienteService.Get();


        [HttpGet("{id}")]
            public async Task<ActionResult<ClienteDto>> GetById(int id)
            {
                var clienteDto = await _clienteService.GetById(id);

                return clienteDto == null ? NotFound() : Ok(clienteDto);
            }

            [HttpPost]
            public async Task<ActionResult<ClienteDto>> Add(ClienteInsertDto ClienteInsertDto)
            {
                //Validacion inyectada
                var validationResult = await _clienteInsertValidator.ValidateAsync(ClienteInsertDto);

                //Nos devuelve badrequest si no cumple con la validacion
                if(!validationResult.IsValid)
                {
                    //.Errors extiende de nuestra clase y nos muestra todos los mensajes de error 
                    return BadRequest(validationResult.Errors);
                }

                var ClienteDto = await _clienteService.Add(ClienteInsertDto);
                
                return CreatedAtAction(nameof(GetById), new {id = ClienteDto.ClienteID}, ClienteDto);
            }

            [HttpPut("{id}")]
            public async Task<ActionResult<ClienteDto>> Update(int id, ClienteUpdateDto ClienteUpdateDto)
            {

                var validationResult = await _ClienteUpdateDto.ValidateAsync(ClienteUpdateDto);
                if(!validationResult.IsValid){
                    return BadRequest(validationResult.Errors);
                }

                var ClienteDto = await _clienteService.Update(id, ClienteUpdateDto);

                return ClienteDto == null ? NotFound() : Ok(ClienteDto);

            }

            [HttpDelete("{id}")]
            public async Task<ActionResult<ClienteDto>> Delete(int id)
            {
                var ClienteDto = await _clienteService.Delete(id);
                return ClienteDto == null ? NotFound() : Ok(ClienteDto);
            }

    }
    
}