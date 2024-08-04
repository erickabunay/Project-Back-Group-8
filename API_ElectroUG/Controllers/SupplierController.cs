using API_ElectroUG.Models;
using API_ElectroUG.Repository;
using BenchmarkDotNet.Reports;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_ElectroUG.Controllers
{
    public class SupplierController : Controller, ISupplierRepository
    {
        private readonly ISupplierRepository _supplierRepository;

        public SupplierController(ISupplierRepository supplierRepository)
        {
            _supplierRepository = supplierRepository;
        }

        /// <summary>
        /// Endpoint que permite crear un nuevo proveedor.
        /// </summary>
        [HttpPost("supplier")]
        public async Task<Supplier> CreateSupplierAsync([FromBody] Supplier supplier)
        {
            return await _supplierRepository.CreateSupplierAsync(supplier);
        }

        /// <summary>
        /// Endpoint que permite deshabilitar un proveedor determinado.
        /// </summary>
        [HttpDelete("supplier/{id}")]
        public async Task<Supplier> DisableSupplierByIdAsync(int id)
        {
            return await _supplierRepository.DisableSupplierByIdAsync(id);
        }

        /// <summary>
        /// Endpoint que obtiene todos los proveedores que se encuentren habilitados.
        /// </summary>
        [HttpGet("GetAllSuppliers")]
        public async Task<List<Supplier>> GetAllSupplierAsync()
        {
            return await _supplierRepository.GetAllSupplierAsync();
        }

        /// <summary>
        /// Endpoint que obtiene todos los proveedores que se encuentren habilitados, y tomará todos los registros 
        /// que sean igual o menor a la fecha pasada como parametro (yyy-MM-dd).
        /// </summary>
        [HttpGet("GetEnabledSuppliersUpToDate/{dateOfEntry}")]
        public async Task<List<Supplier>> GetEnabledSuppliersUpToDateAsync(DateTime dateOfEntry)
        {
            return await _supplierRepository.GetEnabledSuppliersUpToDateAsync(dateOfEntry);
        }

        /// <summary>
        /// Endpoint que filtra por el nombre comercial de un proveedor
        /// </summary>
        [HttpGet("GetSuppliersByTradeName/{tradeName}")]
        public async Task <Supplier> GetSuppliersByTradeNameAsync(string tradeName)
        {
            return await _supplierRepository.GetSuppliersByTradeNameAsync(tradeName);
        }

        /// <summary>
        /// Endpoint que filtra por el Id del proveedor
        /// </summary>
        [HttpGet("GetSupplierById/{id}")]
        public async Task<Supplier> GetSupplierByIdAsync(int id)
        {
            return await _supplierRepository.GetSupplierByIdAsync(id);
        }

        public Task<bool> SaveChangesAsync()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Endpoint que permite la edición del proveedor, con el Id especificado.
        /// </summary>
        [HttpPut("UpdateSupplier/{id}")]
        public async Task<Supplier> UpdateSupplierAsync(int id, [FromBody] Supplier supplier)
        {
            return await _supplierRepository.UpdateSupplierAsync(id, supplier); 
        }
    }
}
