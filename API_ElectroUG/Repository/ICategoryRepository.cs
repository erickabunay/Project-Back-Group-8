using API_ElectroUG.Models;

namespace API_ElectroUG.Repository
{
    public interface ICategoryRepository
    {
        Task<List<Category>> GetAllCategoriesAsync();

        Task<Category> GetCategoryByIdAsync(int categoryId);

        Task<List<Category>> GetCategoriesByNameAsync(string categoryName);

        Task<List<Category>> GetCategoriesByDescriptionAsync(string categoryDescription);

        Task<Category> CreateCategoryAsync(Category createCategory);

        Task<Category> UpdateCategoryAsync(int id,Category updateCategory);

        Task<Category> DeleteCategoryAsync(int categoryId);
    }
}
