using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RetoTecnico.Models
{
    public class Alhaja
    {
        //Hereda de Cliente
        public int ClienteID {get; set;}
        public int IdEstatus { get; set; }
        
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AlhajaID {get; set;}

        public string FolioID { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal PesoKG {get; set;}

        [Column(TypeName = "decimal(18,2)")]
        public decimal PreOroMomento {get; set;}

        [Column(TypeName = "decimal(18,2)")]
        public decimal PorInteresMomento{get; set;}

        [Column(TypeName = "decimal(18,2)")]
        public decimal MontoEmpeño {get; set;}

        [Column(TypeName = "decimal(18,2)")]
        public decimal MontoInteres {get; set;}
        
        [Column(TypeName = "decimal(18,2)")]
        public decimal MontoDeuda {get; set;}
        public DateTime FechaOperacion {get; set;}
        public DateTime FechaVencimiento {get; set;}
        public DateTime? FechaLiquidacion {get; set;}

        [ForeignKey("IdEstatus")]
        public virtual Estatus Estatus { get; set; } 

        [ForeignKey("ClienteID")]
        public virtual Cliente Cliente {get; set;}
    }
}

