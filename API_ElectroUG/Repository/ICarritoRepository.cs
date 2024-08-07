using API_ElectroUG.Models;

public interface ICarritoRepository
{
    Task<IEnumerable<Carrito>> GetAllAsync();
    Task<Carrito> GetByIdAsync(int id);
    Task CreateAsync(Carrito carrito);
    Task<Carrito> UpdateAsync(Carrito carrito);
    Task DeleteByIdAsync(int id);
}
