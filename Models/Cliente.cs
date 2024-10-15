using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RetoTecnico.Models
{
    public class Cliente
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ClienteID {get; set;}
        public string Name {get; set;}

        public string Email { get; set; }
        public List<Folio>? Folios { get; set; } // Relación con los empeños del cliente
    }
}