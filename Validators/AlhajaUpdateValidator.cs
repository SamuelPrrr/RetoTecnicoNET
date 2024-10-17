using System.Data;
using RetoTecnico.DTOs;
using FluentValidation;
using RetoTecnico.Models;

/* IdEstado = 1 = Vigente
IdEstado = 2 = Vencido
IdEstado = 3 = Liquidado
IdEstado = 4 = Cancelado */

namespace RetoTecnico.Validators
 {
  public class AlhajaUpdateValidator : AbstractValidator<AlhajaUpdateDto>{
   public AlhajaUpdateValidator()
        {
            
        }
       
    }
  
  }

 