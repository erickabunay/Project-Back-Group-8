using API_ElectroUG.Context;
using API_ElectroUG.Exceptions;
using API_ElectroUG.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API_ElectroUG.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _context;
        public ProductRepository(AppDbContext context) 
        {
            _context = context;
        }

        public async Task<ActionResult<Product>> CreateProductAsync(Product product)
        {
            #region Validations Basic

            // Validar el objeto 'product' para asegurar que todos los campos requeridos están presentes
            if (product == null)
            {
                return new BadRequestObjectResult("Product cannot be null.");
            }

            if (string.IsNullOrEmpty(product.Name))
            {
                return new BadRequestObjectResult("Product Name is required.");
            }

            if (string.IsNullOrEmpty(product.Description))
            {
                return new BadRequestObjectResult("Product Description is required.");
            }

            if (product.CategoryId == 0) // Asumiendo que 0 no es un valor válido para CategoryId
            {
                return new BadRequestObjectResult("Valid CategoryId is required.");
            }

            if (product.SupplierId == 0) // Asumiendo que 0 no es un valor válido para SupplierId
            {
                return new BadRequestObjectResult("Valid SupplierId is required.");
            }

            if (product.Price <= 0)
            {
                return new BadRequestObjectResult("Product Price must be greater than zero.");
            }

            if (product.Stock <= 0)
            {
                return new BadRequestObjectResult("Product Stock must be greather than zero.");
            }
            #endregion

            if (product.SupplierId != 0)
            {
                var existsSupplierId = await _context.Supplier
                                                     .Where(s => s.Id == product.SupplierId && s.IsDisabled != true)
                                                     .FirstOrDefaultAsync();
                if (existsSupplierId != null) 
                {
                    product.Supplier = existsSupplierId;
                }
                else 
                {
                    throw new ApiException("Operacion no permitida", 400 , $"No se pudo encontrar un proveedor con el id {product.SupplierId}");
                }
            }

            if (product.CategoryId != 0)
            {
                var existsCategoryId = await _context.Category
                                                     .Where(s => s.CategoryId == product.CategoryId && s.IsDisabled != true)
                                                     .FirstOrDefaultAsync();
                if (existsCategoryId != null)
                {
                    product.Category = existsCategoryId;
                }
                else
                {
                    throw new ApiException("Operacion no permitida", 400, $"No se pudo encontrar un proveedor con el id {product.SupplierId}");
                }
            }
            // Si todas las validaciones pasan, añade el producto al contexto y guarda los cambios
            try
            {
                _context.Product.Add(product);
                await _context.SaveChangesAsync();
                return new OkObjectResult(product); // Retorna el producto creado con el ID asignado por la base de datos
            }
            catch (Exception ex)
            {
                // Manejo de excepciones, como errores de conexión a la base de datos, etc.
                return new BadRequestObjectResult($"An error occurred when saving the product: {ex.Message}");
            }
        }

        public async Task<Product> DisabledProductById(int id)
        {
            var existsProduct = await _context.Product.FindAsync(id);

            if (existsProduct != null)
            {
                _context.Entry(existsProduct)
                        .CurrentValues.SetValues(existsProduct.IsDisabled = true);
                await _context.SaveChangesAsync();
                return existsProduct;
            }
            else
            {
                throw new ApiException($"Operación no permitida.", 400, $"No se encontró un producto con el id: {id}.");
            }
        }

        public async Task<List<Product>> GetAllProductsAsync()
        {
            List <Product> products = await _context.Product
                                                    .Where(s => s.IsDisabled != true)
                                                    .ToListAsync();
            foreach (var items in products) 
            {
                if (items.Supplier == null)
                {
                    var supplier = await _context.Supplier.Where(s => s.Id == items.SupplierId && s.IsDisabled != true)
                                                          .FirstOrDefaultAsync();
                    items.Supplier = supplier;

                }

                if (items.Category == null)
                {
                    var category = await _context.Category.Where(s => s.CategoryId == items.CategoryId
                                                         && s.IsDisabled != true)
                                                        .FirstOrDefaultAsync();
                    items.Category = category;

                }
            }

            return products;
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            var product = await _context.Product
                                        .Where(s => s.Id == id 
                                         && s.IsDisabled != true)
                                        .FirstOrDefaultAsync();

            if (product.Supplier == null) 
            {
                var supplier = await _context.Supplier.Where(s => s.Id == product.SupplierId
                                                       && s.IsDisabled != true)
                                                      .FirstOrDefaultAsync();
                product.Supplier = supplier;

            }

            if (product.Category == null) 
            {
                var category = await _context.Category.Where(s => s.CategoryId == product.CategoryId
                                                     && s.IsDisabled != true)
                                                    .FirstOrDefaultAsync();
                product.Category = category;

            }

            return product;
        }

        public async Task<List<Product>> GetProductsByCategoryAsync(string category)
        {
            List <Product> products = await _context.Product
                                                     .Where(s => category.Equals(s.Category.Name) 
                                                      && s.IsDisabled != true)
                                                     .ToListAsync();


            foreach (var items in products)
            {
                if (items.Supplier == null)
                {
                    var supplier = await _context.Supplier.Where(s => s.Id == items.SupplierId && s.IsDisabled != true)
                                                          .FirstOrDefaultAsync();
                    items.Supplier = supplier;

                }

                if (items.Category == null)
                {
                    var categories = await _context.Category.Where(s => s.CategoryId == items.CategoryId
                                                         && s.IsDisabled != true)
                                                        .FirstOrDefaultAsync();
                    items.Category = categories;

                }
            }

            return products;
        }

        public async Task<List<Product>> GetProductsByPriceOrLessAsync(decimal price)
        {
            List<Product> products = await _context.Product
                                                    .Where(s => s.Price <= price 
                                                     && s.IsDisabled != true)
                                                    .ToListAsync();
            foreach (var items in products)
            {
                if (items.Supplier == null)
                {
                    var supplier = await _context.Supplier.Where(s => s.Id == items.SupplierId && s.IsDisabled != true)
                                                          .FirstOrDefaultAsync();
                    items.Supplier = supplier;

                }

                if (items.Category == null)
                {
                    var category = await _context.Category.Where(s => s.CategoryId == items.CategoryId
                                                         && s.IsDisabled != true)
                                                        .FirstOrDefaultAsync();
                    items.Category = category;

                }
            }

            return products;
        }

        public async Task<ActionResult<Product>> UpdateProductByIdAsync(int id, Product updatedProduct)
        {
            if (updatedProduct == null)
            {
                return new BadRequestObjectResult("La información del producto no puede ser nula.");
            }

            var product = await _context.Product.FindAsync(id);
            if (product == null)
            {
                return new NotFoundObjectResult("No se encontró el producto.");
            }

            if (string.IsNullOrEmpty(updatedProduct.Name))
            {
                return new BadRequestObjectResult("El nombre del producto es requerido.");
            }

            if (string.IsNullOrEmpty(updatedProduct.Description))
            {
                return new BadRequestObjectResult("La descripción del producto es requerido.");
            }

            if (updatedProduct.CategoryId == 0) // Assuming 0 is not a valid CategoryId
            {
                return new BadRequestObjectResult("Ingrese una categoria valida.");
            }

            if (updatedProduct.SupplierId == 0) // Assuming 0 is not a valid SupplierId
            {
                return new BadRequestObjectResult("Ingrese un proveedor valido.");
            }

            if (updatedProduct.Price <= 0)
            {
                return new BadRequestObjectResult("El precio del producto debe ser mayor a 0.");
            }

            if (updatedProduct.Stock <= 0)
            {
                return new BadRequestObjectResult("El stock debe ser mayor a 0.");
            }

            if (product.SupplierId != 0)
            {
                var existsSupplierId = await _context.Supplier
                                                     .Where(s => s.Id == product.SupplierId && s.IsDisabled != true)
                                                     .FirstOrDefaultAsync();
                if (existsSupplierId != null)
                {
                    product.Supplier = existsSupplierId;
                }
                else
                {
                    throw new ApiException("Operacion no permitida", 400, $"No se pudo encontrar un proveedor con el id {product.SupplierId}");
                }
            }

            if (product.CategoryId != 0)
            {
                var existsCategoryId = await _context.Category
                                                     .Where(s => s.CategoryId == product.CategoryId && s.IsDisabled != true)
                                                     .FirstOrDefaultAsync();
                if (existsCategoryId != null)
                {
                    product.Category = existsCategoryId;
                }
                else
                {
                    throw new ApiException("Operacion no permitida", 400, $"No se pudo encontrar un proveedor con el id {product.SupplierId}");
                }
            }
            // Si todas las validaciones pasan, añade el producto al contexto y guarda los cambios
            try
            {
                product.Name = updatedProduct.Name;
                product.Description = updatedProduct.Description;
                product.Price = updatedProduct.Price;
                product.Stock = updatedProduct.Stock;
                product.CategoryId = updatedProduct.CategoryId;
                product.SupplierId = updatedProduct.SupplierId;
                product.ProductImg = updatedProduct.ProductImg;

                await _context.SaveChangesAsync();
                return new OkObjectResult(product); // Return the updated product
            }
            catch (Exception ex)
            {
                // Manejo de excepciones, como errores de conexión a la base de datos, etc.
                return new BadRequestObjectResult($"Ocurrió un error cuando se actualizaba el producto: {ex.Message}");
            }
        }

    }
}
