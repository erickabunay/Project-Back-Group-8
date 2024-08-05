using API_ElectroUG.Models;
using Microsoft.AspNetCore.Mvc;

namespace API_ElectroUG.Repository
{
    public interface IProductRepository
    {
        Task<List<Product>> GetAllProductsAsync();

        Task<List<Product>> GetProductsByPriceOrLessAsync(decimal price);

        Task<List<Product>> GetProductsByCategoryAsync(string category);

        Task<Product> GetProductByIdAsync(int id);

        Task<ActionResult<Product>> CreateProductAsync(Product product);

        Task<ActionResult<Product>> UpdateProductByIdAsync(int id, Product product);

        Task<Product> DisabledProductById(int id);


    }
}
