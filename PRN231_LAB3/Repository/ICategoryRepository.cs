using BussiniseObject.Models;

namespace Repository;

public interface ICategoryRepository
{
    Task<IEnumerable<Category>> GetCategories();
    Task<Category> GetCategoryById(int id);
    Task<Category> AddCategory(Category category);
    Task<Category> UpdateCategory(int id, Category category);
    Task<Category> DeleteCategory(int id);
}