using API_ElectroUG.Context;
using API_ElectroUG.Exceptions;
using API_ElectroUG.Models;
using Microsoft.EntityFrameworkCore;

namespace API_ElectroUG.Repository
{
    public class SupplierRepository : ISupplierRepository
    {
        private readonly AppDbContext _context;

        public SupplierRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Supplier> CreateSupplierAsync(Supplier supplier)
        {
            if (supplier != null)
            {
                if (string.IsNullOrWhiteSpace(supplier.BusinessName))
                {

                    throw new ArgumentNullException(nameof(supplier.BusinessName), "El nombre de la compañía es requerido.");
                }

                if (string.IsNullOrWhiteSpace(supplier.TradeName))
                {
                    throw new ArgumentException(nameof(supplier.TradeName), "El Nombre comercial es requerido.");
                }

                if (string.IsNullOrWhiteSpace(supplier.CompanyName))
                {
                    throw new ArgumentException(nameof(supplier.CompanyName), "La Razón social es requerida.");
                }

                if (string.IsNullOrEmpty(supplier.Ruc))
                {
                    throw new ArgumentException(nameof(supplier.Ruc), "El RUC es requerido.");
                }
                else if (supplier.Ruc.Length != 13)
                {
                    throw new ArgumentException("El RUC debe tener 13 dígitos.");
                }

                if (!string.IsNullOrWhiteSpace(supplier.Ruc))
                {
                    bool rucExists = await _context.Supplier.AnyAsync(s => s.Ruc == supplier.Ruc);

                    if (rucExists)
                    {
                        throw new ApiException($"Operación no permitida.", 400, $"El RUC {supplier.Ruc} ya se encuentra registrado.");
                    }
                }


                await _context.Supplier.AddAsync(supplier);
                await _context.SaveChangesAsync();
            }


            return supplier;
        }

        public async Task<Supplier> DisableSupplierByIdAsync(int id)
        {
            var existsSupplier = await _context.Supplier.FindAsync(id);

            if (existsSupplier != null)
            {
                _context.Entry(existsSupplier)
                        .CurrentValues.SetValues(existsSupplier.IsDisabled = true);
                await _context.SaveChangesAsync();
                return existsSupplier;
            }
            else
            {
                throw new ApiException($"Operación no permitida.", 400, $"No se encontró un proveedor con el id: {id}.");
            }
        }

        public async Task<List<Supplier>> GetAllSupplierAsync()
        {
            List<Supplier> suppliers = await _context.Supplier
                                                     .Where(s => s.IsDisabled != true)
                                                     .ToListAsync();

            return suppliers;
        }

        public async Task<List<Supplier>> GetEnabledSuppliersUpToDateAsync(DateTime dateOfEntry)
        {
            List<Supplier> suppliers = await _context.Supplier
                                                     .Where(s => s.IsDisabled != true
                                                      && s.DateOfEntry.Date <= dateOfEntry.Date)
                                                     .ToListAsync();
            return suppliers;
        }

        public async Task<Supplier> GetSuppliersByTradeNameAsync(string tradeName)
        {
            Supplier suppliers = await _context.Supplier
                                                .Where(s => s.IsDisabled != true
                                                 && s.TradeName == tradeName)
                                                .FirstOrDefaultAsync();
            return suppliers;
        }

        public async Task<Supplier> GetSupplierByIdAsync(int id)
        {
            Supplier supplier = await _context.Supplier
                                              .Where(s => s.Id == id
                                               && s.IsDisabled != true)
                                              .FirstOrDefaultAsync();
            return supplier;
        }

        public async Task<Supplier> UpdateSupplierAsync(int id, Supplier supplier)
        {
            var existsSupplier = await _context.Supplier.FirstOrDefaultAsync(s => s.Id == id);

            if (existsSupplier != null)
            {
                _context.Entry(existsSupplier).CurrentValues.SetValues(supplier);
                await _context.SaveChangesAsync();
                return existsSupplier;
            }
            else
            {
                throw new ApiException("Operación no permitida", 400, $"El proveedor con el Id: {id} no existe.");
            }
        }
    }
}
