using API_ElectroUG.Context;
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
                        throw new InvalidOperationException($"El RUC {supplier.Ruc} ya se encuentra registrado.");
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
                throw new Exception("No se encontró un proveedor con el " + id + " especificado.");
            }
        }

        public Task<List<Supplier>> GetAllSupplierAsync()
        {
            throw new NotImplementedException();
        }

        public Task<List<Supplier>> GetSupplerByDateOfEntryAsync(DateTime dateOfEntry)
        {
            throw new NotImplementedException();
        }

        public Task<List<Supplier>> GetSupplierByBusinessNameAsync(string businessName)
        {
            throw new NotImplementedException();
        }

        public Task<Supplier> GetSupplierByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public Task<Supplier> UpdateSupplierAsync(Supplier supplier)
        {
            throw new NotImplementedException();
        }
    }
}
