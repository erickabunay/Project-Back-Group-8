using API_ElectroUG.Context;
using API_ElectroUG.Exceptions;
using API_ElectroUG.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API_ElectroUG.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppDbContext _context;

        public CategoryRepository(AppDbContext context) 
        {
            _context = context;
        }

        public async Task<Category> CreateCategoryAsync(Category createCategory)
        {
            try
            {
                if (createCategory != null) 
                {
                    if (string.IsNullOrEmpty(createCategory.Name))
                    {
                        throw new Exception("El nombre de la categoria es requerido.");
                    }

                    if (string.IsNullOrEmpty(createCategory.Description))
                    {
                        throw new Exception("La descripción de la categoria es requerida.");
                    }

                    _context.Category.Add(createCategory);
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al intentar crear la categoria "+ ex);
                
            }

            return (createCategory);
           
        }

        public async Task<Category> DeleteCategoryAsync(int categoryId)
        {
            var existsCategory = await _context.Category.FindAsync(categoryId);

            if (existsCategory != null)
            {
                _context.Entry(existsCategory)
                        .CurrentValues.SetValues(existsCategory.IsDisabled = true);
                await _context.SaveChangesAsync();
                return existsCategory;
            }
            else
            {
                throw new ApiException($"Operación no permitida.", 400, $"No se encontró una categoria con el id: {categoryId}.");
            }
        }

        public async Task<List<Category>> GetAllCategoriesAsync()
        {
            List<Category> categories = await _context.Category
                                                        .Where(c => c.IsDisabled != true)
                                                        .ToListAsync();

            return categories;
        }

        public async Task<List<Category>> GetCategoriesByNameAsync(string categoryName)
        {
            List<Category> categories = await _context.Category
                                                      .Where(c => c.Name == categoryName 
                                                       && c.IsDisabled != true)
                                                      .ToListAsync();
            return categories;
        }

        public async Task<List<Category>> GetCategoriesByDescriptionAsync(string categoryDescription)
        {
            List<Category> categories = await _context.Category
                                                     .Where(c => c.Description == categoryDescription
                                                      && c.IsDisabled != true)
                                                     .ToListAsync();
            return categories;

        }

        public async Task<Category> GetCategoryByIdAsync(int categoryId)
        {
            var category = await _context.Category
                                         .Where(c => c.CategoryId == categoryId 
                                          && c.IsDisabled != true)
                                         .FirstOrDefaultAsync();

            return category;
        }

        public async Task<Category> UpdateCategoryAsync(int id, Category updateCategory)
        {
            var categoryExists = await _context.Category.FindAsync(updateCategory.CategoryId);

            try
            {

                if (categoryExists != null)
                {
                    if (string.IsNullOrEmpty(updateCategory.Name))
                    {
                        throw new Exception("El nombre de la categoria es requerido.");
                    }

                    if (string.IsNullOrEmpty(updateCategory.Description))
                    {
                        throw new Exception("La descripción de la categoria es requerida.");
                    }

                    categoryExists.Name = updateCategory.Name;
                    categoryExists.Description = updateCategory.Description;
                    categoryExists.IsDisabled = updateCategory.IsDisabled;

                    await _context.SaveChangesAsync();
                }
                else 
                {
                    throw new Exception($"No se encontró la categoria con el id: {updateCategory.CategoryId}");
                  
                }
            }
            catch (Exception ex) 
            {
                throw new Exception("Ocurrió un error al intentar actualizar la categoria " + ex);
            }

            return categoryExists;

        }
    }
}
