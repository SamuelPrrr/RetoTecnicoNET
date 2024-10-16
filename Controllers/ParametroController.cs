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
    public class ParametroController : ControllerBase
    {
        
         private ICommonService<ParametroDto,ParametroInsertDto,ParametroUpdateDto> _parametroService;
         //Validador
         private IValidator<ParametroInsertDto> _parametroInsertValidator;
         private IValidator<ParametroUpdateDto> _parametroUpdateValidator;
         public ParametroController(IValidator<ParametroInsertDto> parametroInsertValidator, IValidator<ParametroUpdateDto> ParametroUpdateValidator,
            ICommonService<ParametroDto, ParametroInsertDto, ParametroUpdateDto> clienteService)
         {
            _parametroInsertValidator = parametroInsertValidator;
            _parametroUpdateValidator = ParametroUpdateValidator;
            _parametroService = clienteService;
         }

        [HttpGet]            
         public async Task<IEnumerable<ParametroDto>> Get() => 
            await _parametroService.Get();


        [HttpGet("{id}")]
            public async Task<ActionResult<ParametroDto>> GetById(int id)
            {
                var ParametroDto = await _parametroService.GetById(id);

                return ParametroDto == null ? NotFound() : Ok(ParametroDto);
            }

            [HttpPost]
            public async Task<ActionResult<ParametroDto>> Add(ParametroInsertDto ParametroInsertDto)
            {
                //Validacion inyectada
                var validationResult = await _parametroInsertValidator.ValidateAsync(ParametroInsertDto);

                //Nos devuelve badrequest si no cumple con la validacion
                if(!validationResult.IsValid)
                {
                    //.Errors extiende de nuestra clase y nos muestra todos los mensajes de error 
                    return BadRequest(validationResult.Errors);
                }

                var ParametroDto = await _parametroService.Add(ParametroInsertDto);
                
                return CreatedAtAction(nameof(GetById), new {id = ParametroDto.ParametroID}, ParametroDto);
            }

            [HttpPut("{id}")]
            public async Task<ActionResult<ParametroDto>> Update(int id, ParametroUpdateDto ParametroUpdateDto)
            {

                var validationResult = await _parametroUpdateValidator.ValidateAsync(ParametroUpdateDto);
                if(!validationResult.IsValid){
                    return BadRequest(validationResult.Errors);
                }

                var ParametroDto = await _parametroService.Update(id, ParametroUpdateDto);

                return ParametroDto == null ? NotFound() : Ok(ParametroDto);

            }

            [HttpDelete("{id}")]
            public async Task<ActionResult<ParametroDto>> Delete(int id)
            {
                var ParametroDto = await _parametroService.Delete(id);
                return ParametroDto == null ? NotFound() : Ok(ParametroDto);
            }

    }
    
}