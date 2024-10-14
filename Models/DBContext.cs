using Microsoft.EntityFrameworkCore;
namespace RetoTecnico.Models
{
    public class DBConnection : DbContext
    {
        public DBConnection(DbContextOptions<DBConnection> options): base(options)
        {
            
        }
        public DbSet<Cliente> Clientes {get; set;}
        public DbSet<Alhaja> Alhaja {get; set;}
        public DbSet<Folio> Folios {get; set;}
    }
}