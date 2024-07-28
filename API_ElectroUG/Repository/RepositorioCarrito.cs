using API_ElectroUG.Context;
using API_ElectroUG.Models;
using Microsoft.EntityFrameworkCore;

namespace API_ElectroUG.Repository
{
    public class RepositorioCarrito
    {
        private readonly AppDbContext context;
        public RepositorioCarrito(AppDbContext context)
        {
            this.context = context;
        }
        public async Task<int> Crear(Carrito carrito)
        {
            context.carrito.Add(carrito);
            await context.SaveChangesAsync();

            return carrito.Id;
        }
        public async Task Eliminar(int id)
        {
            Carrito carrito = await context.carrito.FindAsync(id);
            context.carrito.Remove(carrito);
            await context.SaveChangesAsync();
        }
        public async Task<IEnumerable<Carrito>> GetEnviadosAsync()
        {
            return await context.carrito
                .Include(c => c.Productos)
                .Where(c => c.Estado == "enviado")
                .ToListAsync();
        }
        public async Task<List<Carrito>> ObtenerTodos()
        {
            return await context.carrito.ToListAsync();
        }
        public async Task<Carrito?> ObtenerPorId(int id)
        {
            //return await context.Autores.FindAsync(id);
            return context.carrito.Where(x => x.Id == id)
                .Include(x => x.Id)
                .ToList()[0];

        }

    }
}
