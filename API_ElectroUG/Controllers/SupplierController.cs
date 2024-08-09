using API_ElectroUG.Exceptions;
using API_ElectroUG.Models;
using API_ElectroUG.Repository;
using BenchmarkDotNet.Reports;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Diagnostics.Runtime.Utilities;

namespace API_ElectroUG.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
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
            var result = await _supplierRepository.GetAllSupplierAsync();

            return result == null ? throw new ApiException("No hay resultados", 404, "No se encontraron resultados.") : result;
        }

        /// <summary>
        /// Endpoint que obtiene todos los proveedores que se encuentren habilitados, y tomará todos los registros 
        /// que sean igual o menor a la fecha pasada como parametro (yyy-MM-dd).
        /// </summary>
        [HttpGet("GetEnabledSuppliersUpToDate/{dateOfEntry}")]
        public async Task<List<Supplier>> GetEnabledSuppliersUpToDateAsync(DateTime dateOfEntry)
        {
            var result = await _supplierRepository.GetEnabledSuppliersUpToDateAsync(dateOfEntry);
            return result == null ? throw new ApiException("No hay resultados", 404, "No se encontraron resultados.") : result;

        }

        /// <summary>
        /// Endpoint que filtra por el nombre comercial de un proveedor
        /// </summary>
        [HttpGet("GetSuppliersByTradeName/{tradeName}")]
        public async Task <Supplier> GetSuppliersByTradeNameAsync(string tradeName)
        {
            var result = await _supplierRepository.GetSuppliersByTradeNameAsync(tradeName);
            return result == null ? throw new ApiException("No hay resultados", 404, "No se encontraron resultados.") : result;

        }

        /// <summary>
        /// Endpoint que filtra por el Id del proveedor
        /// </summary>
        [HttpGet("GetSupplierById/{id}")]
        public async Task<Supplier> GetSupplierByIdAsync(int id)
        {
            var result =  await _supplierRepository.GetSupplierByIdAsync(id);
            return result == null ? throw new ApiException("No hay resultados", 404, "No se encontraron resultados.") : result;

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
