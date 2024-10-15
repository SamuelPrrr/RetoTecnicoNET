using Microsoft.EntityFrameworkCore;
using RetoTecnico.Models;


namespace RetoTecnico.Repository
{
    public class ClienteRepository : IRepository<Cliente>
    {
        private DBContext _context;

        //Vamos a asignar esto para que el repo se enfoque en la concexion a BD y servicio a las reglas de negocio
        public ClienteRepository(DBContext context)
        {
            _context = context;
        }
        
        //El repo nos devuelve una entidad hacia el servicio y el servicio se encarga de esa entidad
        public async Task<IEnumerable<Cliente>> Get()
            => await _context.Clientes.ToListAsync();
            
        public async Task<Cliente> GetById(int id)
            => await _context.Clientes.FindAsync(id);

        public async Task Add(Cliente cliente)
            => await _context.Clientes.AddAsync(cliente);
        public void Update(Cliente cliente)
        {
            //attach adjunta la entidad a tuc ontexto pero cuando ya existe
            _context.Clientes.Attach(cliente);
            _context.Clientes.Entry(cliente).State = EntityState.Modified;
        }

        public void Delete(Cliente cliente)
            => _context.Clientes.Remove(cliente);

        public async Task Save()
            => await _context.SaveChangesAsync();

        public IEnumerable<Cliente> Search(Func<Cliente, bool> filter) =>
        _context.Clientes.Where(filter).ToList(); 
    }
        
}