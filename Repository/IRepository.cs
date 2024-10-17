

//El repositorio en pocas palabras se encarga de manejas la BD
namespace RetoTecnico.Repository
{
    //T tipo de parametro, en cambio TEntity hace referencia a que trabajamos con un repositorio
    //Todas las capas se tienen que inyectar
    public interface IRepository<TEntity>
    {
        Task<IEnumerable<TEntity>> Get();
        Task<TEntity> GetById(int id);
        Task Add(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        Task Save();
        IEnumerable<TEntity> Search(Func<TEntity, bool> filter);
    }
}