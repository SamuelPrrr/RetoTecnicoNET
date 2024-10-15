using System.Data;
using RetoTecnico.DTOs;
using FluentValidation;
using RetoTecnico.Models;

namespace RetoTecnico.Validators
 {
    //CONTENDRA UN GENERIC QUE ES EL MODELO O DTO QUE OBTENEMOS COMO RESPUESTA EN NUESTRA SOLICITUD 
  public class ClienteUpdateValidator : AbstractValidator<ClienteUpdateDto>{
    public ClienteUpdateValidator(){
        //Creamos regla 
        //RuleFor(x => x.Name).NotEmpty();

        //Tambien le podemos agregar mensajes personalizados
        RuleFor(x => x.ClienteID).NotNull().WithMessage("El ID es obligatorio");
        RuleFor(x => x.Name).NotEmpty().WithMessage("El nombre es obligatorio");
        RuleFor(x => x.Name).Length(2, 20).WithMessage("El nombre debe ser de entre 2 a 20 caracteres");
    }
    
  }
 }