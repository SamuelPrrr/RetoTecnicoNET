using Microsoft.EntityFrameworkCore;
using RetoTecnico.Models;


namespace RetoTecnico.Repository
{
    public class ParametrosRepository : IRepository<Parametros>
    {
        private DBContext _context;

        //Vamos a asignar esto para que el repo se enfoque en la concexion a BD y servicio a las reglas de negocio
        public ParametrosRepository(DBContext context)
        {
            _context = context;
        }
        
        //El repo nos devuelve una entidad hacia el servicio y el servicio se encarga de esa entidad
        public async Task<IEnumerable<Parametros>> Get()
            => await _context.Parametros.ToListAsync();
            
        public async Task<Parametros> GetById(int id)
            => await _context.Parametros.FindAsync(id);

        public async Task Add(Parametros Parametros)
            => await _context.Parametros.AddAsync(Parametros);
        public void Update(Parametros Parametros)
        {
            //attach adjunta la entidad a tuc ontexto pero cuando ya existe
            _context.Parametros.Attach(Parametros);
            _context.Parametros.Entry(Parametros).State = EntityState.Modified;
        }
        public void Delete(Parametros Parametros)
            => _context.Parametros.Remove(Parametros);

        public async Task Save()
            => await _context.SaveChangesAsync();

        public IEnumerable<Parametros> Search(Func<Parametros, bool> filter) =>
        _context.Parametros.Where(filter).ToList(); 
    }

}