using API_ElectroUG.Models;

namespace API_ElectroUG.Repository
{
    public interface ISupplierRepository
    {
        Task<List<Supplier>> GetAllSupplierAsync();

        Task<Supplier> GetSupplierByIdAsync(int id);

        Task<List<Supplier>> GetSupplierByBusinessNameAsync(string businessName);

        Task<List<Supplier>> GetSupplerByDateOfEntryAsync(DateTime dateOfEntry);

        Task<Supplier> CreateSupplierAsync(Supplier supplier);

        Task<Supplier> UpdateSupplierAsync(Supplier supplier);

        Task<Supplier> DisableSupplierByIdAsync(int id);

        Task<bool> SaveChangesAsync();
    }
}
