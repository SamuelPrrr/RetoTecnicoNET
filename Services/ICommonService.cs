//ActionResult es de part del controlador
namespace RetoTecnico.Services
{
    public interface ICommonService<T, TI, TU>
    {
        //Lista con los errores
        public List<string> Errors {get;}
        //Ocupamos IEnumerable que de hecho List lo implementa pero en este caso 
        //solo ocupamos este por que solo necesitamos un enumberable que solo es de lectura
         public Task<IEnumerable<T>> Get();
         public Task<T> GetById(int id);
         public Task<T> Add(TI insertDto);
         public Task<T> Update(int id, TU updateDto);
         public Task<T> Delete(int id);
         bool Validate(TI dto);
         bool Validate(TU dto);
    }
}