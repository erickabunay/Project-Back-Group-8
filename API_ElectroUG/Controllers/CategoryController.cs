using API_ElectroUG.Models;
using API_ElectroUG.Repository;
using Microsoft.AspNetCore.Mvc;

namespace API_ElectroUG.Controllers
{
    public class CategoryController : Controller, ICategoryRepository
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryController(ICategoryRepository categoryRepository) 
        {
            _categoryRepository = categoryRepository;
        }

        [HttpPost("CreateCategory")]
        public async Task<Category> CreateCategoryAsync([FromBody] Category createCategory)
        {
            return await _categoryRepository.CreateCategoryAsync(createCategory);
        }

        [HttpDelete("DeleteCategory/{categoryId}")]
        public async Task<Category> DeleteCategoryAsync(int categoryId)
        {
            return await _categoryRepository.DeleteCategoryAsync(categoryId);
        }

        [HttpGet("GetAllCategories")]
        public async Task<List<Category>> GetAllCategoriesAsync()
        {
            return await _categoryRepository.GetAllCategoriesAsync();   
        }

        [HttpGet("GetCategoriesByDescription/{categoryDescription}")]
        public async Task<List<Category>> GetCategoriesByDescriptionAsync(string categoryDescription)
        {
            return await _categoryRepository.GetCategoriesByDescriptionAsync(categoryDescription);
        }

        [HttpGet("GetCategoriesByName/{categoryName}")]
        public async Task<List<Category>> GetCategoriesByNameAsync(string categoryName)
        {
            return await _categoryRepository.GetCategoriesByNameAsync(categoryName);
        }

        [HttpGet("GetCategoryById/{categoryId}")]
        public async Task<Category> GetCategoryByIdAsync(int categoryId)
        {
            return await _categoryRepository.GetCategoryByIdAsync(categoryId);
        }

        [HttpPut("UpdateCategory")]
        public async Task<Category> UpdateCategoryAsync(int id, [FromBody] Category updateCategory)
        {
            return await _categoryRepository.UpdateCategoryAsync(id, updateCategory);
        }
    }
}
