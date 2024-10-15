using RetoTecnico.Models;

namespace RetoTecnico.DTOs
{
    public class ClienteInsertDto
    {
        public int ClienteID {get; set;}
        public string Name {get; set;}
        public string Email { get; set; }
        public List<Folio>? Folios { get; set; }
    }
}
