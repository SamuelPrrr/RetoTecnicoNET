using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RetoTecnico.Services;
using RetoTecnico.DTOs;
using RetoTecnico.Models;
using RetoTecnico.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Diagnostics;
using FluentValidation;



namespace RetoTecnico.Controllers
{   
    //[controller] define el nombre del controlador pero sin controller, como que estamos eliminando esa
    [Route("api/[controller]")]
    [ApiController]
    public class AlhajaController : ControllerBase
    {
        private IRepository<Cliente> _clienteRepository;
         private ICommonService<AlhajaDto,AlhajaInsertDto,AlhajaUpdateDto> _alhajaService;
         //Validador
         private IValidator<AlhajaInsertDto> _alhajaInsertValidator;

         private IValidator<AlhajaUpdateDto> _alhajaUpdateValidator;
         
         public AlhajaController
         (IValidator<AlhajaInsertDto> clienteInsertValidator, IValidator<AlhajaUpdateDto> AlhajaUpdateValidator,
            ICommonService<AlhajaDto, AlhajaInsertDto, AlhajaUpdateDto> clienteService, IRepository<Cliente> clienteRepository)
         {
            _alhajaInsertValidator = clienteInsertValidator;
            _alhajaUpdateValidator = AlhajaUpdateValidator;
            _alhajaService = clienteService;
            _clienteRepository = clienteRepository;
         }

        [HttpGet]            
         public async Task<IEnumerable<AlhajaDto>> Get() => 
            await _alhajaService.Get();


        [HttpGet("{id}")]
            public async Task<ActionResult<AlhajaDto>> GetById(int id)
            {
                var AlhajaDto = await _alhajaService.GetById(id);

                return AlhajaDto == null ? NotFound() : Ok(AlhajaDto);
            }
 
            [HttpPost("{id}")]
            public async Task<ActionResult<AlhajaDto>> Add(AlhajaInsertDto alhajaInsertDto, int id)
            {
                //Validacion inyectada
                var validationResult = await _alhajaInsertValidator.ValidateAsync(alhajaInsertDto);

                var existClient = await _clienteRepository.GetById(id);
    
                if (existClient == null)
                {
                    return NotFound(new { message = "Cliente no encontrado" });
                }

                if (existClient.ClienteID != alhajaInsertDto.ClienteID)
                {
                    return BadRequest(new { message = "El ClienteID no coincide." });
                }

                //Nos devuelve badrequest si no cumple con la validacion
                if(!validationResult.IsValid)
                {
                    //.Errors extiende de nuestra clase y nos muestra todos los mensajes de error 
                    return BadRequest(validationResult.Errors);
                }

                //En un momento añado las validaciones
                if(!_alhajaService.Validate(alhajaInsertDto))
                {
                    return BadRequest(_alhajaService.Errors);
                }

                var alhajaDto = await _alhajaService.Add(alhajaInsertDto);
                
                return CreatedAtAction(nameof(GetById), new {id = alhajaDto.ClienteID}, alhajaDto);
            }

            [HttpPut("{id}")]
            public async Task<ActionResult<AlhajaDto>> Update(int id, AlhajaUpdateDto AlhajaUpdateDto)
            {

                var validationResult = await _alhajaUpdateValidator.ValidateAsync(AlhajaUpdateDto);

                //Validadores(MAs que nada de tipo y restricciones basicas de la base de datos)
                if(!validationResult.IsValid){
                    return BadRequest(validationResult.Errors);
                } 

                if(!_alhajaService.Validate(AlhajaUpdateDto))
                {
                    return BadRequest(_alhajaService.Errors);
                }

                var AlhajaDto = await _alhajaService.Update(id, AlhajaUpdateDto);

                return AlhajaDto == null ? NotFound() : Ok(AlhajaDto);

            }

            [HttpDelete("{id}")]
            public async Task<ActionResult<AlhajaDto>> Delete(int id)
            {
                var AlhajaDto = await _alhajaService.Delete(id);
                return AlhajaDto == null ? NotFound() : Ok(AlhajaDto);
            }

    }
    
}