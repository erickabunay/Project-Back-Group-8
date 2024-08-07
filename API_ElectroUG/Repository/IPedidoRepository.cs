using API_ElectroUG.Models;

public interface IPedidoRepository
{
    Task<IEnumerable<Pedido>> GetAllAsync();
    Task<Pedido> GetByIdAsync(int id);
    Task CreateAsync(Pedido pedido);
    Task<Pedido> UpdateAsync(Pedido pedido);
    Task DeleteByIdAsync(int id);
}
