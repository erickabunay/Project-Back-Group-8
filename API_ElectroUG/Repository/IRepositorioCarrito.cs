using API_ElectroUG.Models;

namespace API_ElectroUG.Repository
{
    public interface IRepositorioCarrito
    {
        Task<int> Crear(Carrito carrito);
        Task Eliminar(int id);
        Task<IEnumerable<Carrito>> GetEnviadosAsync();
        Task<List<Carrito>> ObtenerTodos();
        Task ObtenerPorId(int id);
    }
  
}
