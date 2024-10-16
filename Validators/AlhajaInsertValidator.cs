
using System.Data;
using RetoTecnico.DTOs;
using FluentValidation;
using RetoTecnico.Models;

namespace RetoTecnico.Validators
 {
    //CONTENDRA UN GENERIC QUE ES EL MODELO O DTO QUE OBTENEMOS COMO RESPUESTA EN NUESTRA SOLICITUD 
  public class AlhajaInsertValidator : AbstractValidator<AlhajaInsertDto>{
    public AlhajaInsertValidator(){
    }
  }
 }