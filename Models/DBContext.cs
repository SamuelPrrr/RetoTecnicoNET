using Microsoft.EntityFrameworkCore;
namespace RetoTecnico.Models
{
    public class DBContext : DbContext
    {
        public DBContext(DbContextOptions<DBContext> options): base(options)
        {
            
        }
        public DbSet<Cliente> Clientes {get; set;}
        public DbSet<Alhaja> Alhaja {get; set;}
        public DbSet<Parametros> Parametros {get; set;}
    }
}