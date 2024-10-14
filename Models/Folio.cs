using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RetoTecnico.Models
{
    public class Folio
    {
        public int AlhajaID {get; set;}

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int FolioID {get; set;}

        [Column(TypeName = "decimal(18,2)")]
        public decimal PrecioGramo {get; set;}

        [Column(TypeName = "decimal(18,2)")]
        public decimal Interes {get; set;}

        [Column(TypeName = "decimal(18,2)")]
        public decimal MontoEmpeño {get; set;}

        [Column(TypeName = "decimal(18,2)")]
        public decimal MontoInteres {get; set;}

        public DateTime FechaOperacion {get; set;}

        public DateTime FechaVencimiento {get; set;}

        public DateTime? FechaLiquidacion {get; set;}

        [ForeignKey("AlhajaID")]
        public virtual Alhaja Alhaja {get; set;}

    }
}