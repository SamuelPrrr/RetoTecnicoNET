using Microsoft.EntityFrameworkCore;
using RetoTecnico.Models;


namespace RetoTecnico.Repository
{
    public class AlhajaRepository : IRepository<Alhaja>
    {
        private DBContext _context;

        //Vamos a asignar esto para que el repo se enfoque en la concexion a BD y servicio a las reglas de negocio
        public AlhajaRepository(DBContext context)
        {
            _context = context;
        }
        
        //El repo nos devuelve una entidad hacia el servicio y el servicio se encarga de esa entidad
        public async Task<IEnumerable<Alhaja>> Get()
            => await _context.Alhaja.ToListAsync();
            
        public async Task<Alhaja> GetById(int id)
            => await _context.Alhaja.FindAsync(id);

        public async Task Add(Alhaja Alhaja)
            => await _context.Alhaja.AddAsync(Alhaja);
        public void Update(Alhaja Alhaja)
        {
            //attach adjunta la entidad a tuc ontexto pero cuando ya existe
            _context.Alhaja.Attach(Alhaja);
            _context.Alhaja.Entry(Alhaja).State = EntityState.Modified;
        }

        public void Delete(Alhaja Alhaja)
            => _context.Alhaja.Remove(Alhaja);

        public async Task Save()
            => await _context.SaveChangesAsync();

        public IEnumerable<Alhaja> Search(Func<Alhaja, bool> filter) =>
        _context.Alhaja.Where(filter).ToList(); 
    }

}