using API_ElectroUG.Models;

namespace API_ElectroUG.Repository
{
    public interface ISupplierRepository
    {
        Task<List<Supplier>> GetAllSupplierAsync();

        Task<Supplier> GetSupplierByIdAsync(int id);

        Task<Supplier> GetSuppliersByTradeNameAsync(string tradeName);

        Task<List<Supplier>> GetEnabledSuppliersUpToDateAsync(DateTime dateOfEntry);

        Task<Supplier> CreateSupplierAsync(Supplier supplier);

        Task<Supplier> UpdateSupplierAsync(int id, Supplier supplier);

        Task<Supplier> DisableSupplierByIdAsync(int id);

    }
}
