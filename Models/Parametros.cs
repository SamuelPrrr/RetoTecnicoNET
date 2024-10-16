using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RetoTecnico.Models
{
    public class Parametros
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ParametroID {get; set;}

        [Column(TypeName = "decimal(18,2)")]
        public decimal PrecioGramo {get; set;}

        [Column(TypeName = "decimal(18,2)")]
        public decimal Interes {get; set;}

        [Column(TypeName = "decimal(18,2)")]
        public decimal MontoAcumulado {get; set;}
        public int limOperaciones {get; set;}
    }
}

