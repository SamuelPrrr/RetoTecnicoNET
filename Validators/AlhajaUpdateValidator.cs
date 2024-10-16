using System.Data;
using RetoTecnico.DTOs;
using FluentValidation;
using RetoTecnico.Models;

namespace RetoTecnico.Validators
 {
  public class AlhajaUpdateValidator : AbstractValidator<AlhajaUpdateDto>{
    public AlhajaUpdateValidator(){
      RuleFor(x => x)
        .Must(alhaja => FechaLiquidacionEsValida(alhaja.FechaVencimiento, alhaja.FechaLiquidacion, alhaja.IdEstatus))
        .WithMessage("El empeño ha superado su fecha de vencimiento y no puede ser liquidado.");
    }
    private bool FechaLiquidacionEsValida(DateTime? fechaVencimiento, DateTime? fechaLiquidacion, int estatusId)
    {
      return estatusId != 3 /* liquidado */ && estatusId != 4 /* cancelado */
           && fechaLiquidacion.HasValue && fechaLiquidacion.Value <= fechaVencimiento;
    }
    }
  
  }

 