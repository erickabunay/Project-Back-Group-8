using API_ElectroUG.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using API_ElectroUG.Models;

public class CarritoRepository : ICarritoRepository
{
    private readonly AppDbContext _context;

    public CarritoRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Carrito>> GetAllAsync()
    {
        return await _context.Carritos.ToListAsync();
    }

    public async Task<Carrito> GetByIdAsync(int id)
    {
        return await _context.Carritos.FindAsync(id);
    }

    public async Task CreateAsync(Carrito carrito)
    {
        await _context.Carritos.AddAsync(carrito);
        await _context.SaveChangesAsync();
    }

    public async Task<Carrito> UpdateAsync(Carrito carrito)
    {
        var existingCarrito = await _context.Carritos.FindAsync(carrito.CarritoId);
        if (existingCarrito != null)
        {
            _context.Entry(existingCarrito).CurrentValues.SetValues(carrito);
            await _context.SaveChangesAsync();
            return existingCarrito;
        }
        return null;
    }

    public async Task DeleteByIdAsync(int id)
    {
        var carrito = await _context.Carritos.FindAsync(id);
        if (carrito != null)
        {
            _context.Carritos.Remove(carrito);
            await _context.SaveChangesAsync();
        }
    }
}
