using API_ElectroUG.Models;
using API_ElectroUG.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_ElectroUG.Controllers
{

    public class ProductController : Controller, IProductRepository
    {
        private readonly IProductRepository _productRepository;
        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpPost("Product")]
        public async Task<ActionResult<Product>> CreateProductAsync([FromBody]Product product)
        {
            return await _productRepository.CreateProductAsync(product);    
        }

        [HttpDelete("Delete/{id}")]
        public async Task<Product> DisabledProductById(int id)
        {
            return await _productRepository.DisabledProductById(id);
        }

        [HttpGet("GetAllProducts")]
        public async Task<List<Product>> GetAllProductsAsync()
        {
            return await _productRepository.GetAllProductsAsync();
        }

        [HttpGet("GetProductById/{id}")]
        public async Task<Product> GetProductByIdAsync(int id)
        {
            return await _productRepository.GetProductByIdAsync(id);
        }

        [HttpGet("GetProductsByCategory/{category}")]
        public async Task<List<Product>> GetProductsByCategoryAsync(string category)
        {
            return await _productRepository.GetProductsByCategoryAsync(category);
        }

        [HttpGet("GetProductsByPriceOrLess/{price}")]
        public async Task<List<Product>> GetProductsByPriceOrLessAsync(decimal price)
        {
            return await _productRepository.GetProductsByPriceOrLessAsync(price);
        }

        [HttpPut("UpdateProductById/{id}")]
        public async Task<ActionResult<Product>> UpdateProductByIdAsync(int id, [FromBody] Product product)
        {
            return await _productRepository.UpdateProductByIdAsync(id, product);    
        }
    }
}
