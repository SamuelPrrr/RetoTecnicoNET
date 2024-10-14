using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RetoTecnico.Models
{
    public class Alhaja
    {
        //Hereda de Cliente
        public int ClienteID {get; set;}
        
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AlhajaID {get; set;}

        [Column(TypeName = "decimal(18,2)")]
        public decimal PesoKG {get; set;}

        [ForeignKey("ClienteID")]
        public virtual Cliente Cliente {get; set;}
    }
}
