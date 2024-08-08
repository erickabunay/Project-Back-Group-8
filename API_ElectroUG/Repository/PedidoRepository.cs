using API_ElectroUG.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using API_ElectroUG.Models;
public class PedidoRepository : IPedidoRepository
{
    private readonly AppDbContext _context;

    public PedidoRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Pedido>> GetAllAsync()
    {
        return await _context.Pedidos.ToListAsync();
    }

    public async Task<Pedido> GetByIdAsync(int id)
    {
        return await _context.Pedidos.FindAsync(id);
    }

    public async Task CreateAsync(Pedido pedido)
    {
        await _context.Pedidos.AddAsync(pedido);
        await _context.SaveChangesAsync();
    }

    public async Task<Pedido> UpdateAsync(Pedido pedido)
    {
        var existingPedido = await _context.Pedidos.FindAsync(pedido.PedidoId);
        if (existingPedido != null)
        {
            _context.Entry(existingPedido).CurrentValues.SetValues(pedido);
            await _context.SaveChangesAsync();
            return existingPedido;
        }
        return null;
    }

    public async Task DeleteByIdAsync(int id)
    {
        var pedido = await _context.Pedidos.FindAsync(id);
        if (pedido != null)
        {
            _context.Pedidos.Remove(pedido);
            await _context.SaveChangesAsync();
        }
    }
}
