using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RetoTecnico.Models
{
    public class Estatus
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdEstatus {get; set;}
        public string Name {get; set;}
    }
}