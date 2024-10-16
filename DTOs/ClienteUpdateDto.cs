using RetoTecnico.Models;

namespace RetoTecnico.DTOs
{
    public class ClienteUpdateDto
    {
        public int ClienteID {get; set;}
        public string Name {get; set;}
        public string Email { get; set; }
        public List<Alhaja>? Alhajas { get; set; }
    }
}
