using BussiniseObject.Models;
using Dao;

namespace Repository;

public class CategoryRepository : ICategoryRepository
{
    private readonly CategoryDao _categoryDao;

    public CategoryRepository(CategoryDao categoryDao)
    {
        _categoryDao = categoryDao;
    }

    public async Task<IEnumerable<Category>> GetCategories()
    {
        return await _categoryDao.GetCategories();
    }

    public async Task<Category> GetCategoryById(int id)
    {
        return await _categoryDao.GetCategoryById(id);
    }

    public async Task<Category> AddCategory(Category category)
    {
        return await _categoryDao.AddCategory(category);
    }

    public async Task<Category> UpdateCategory(int id, Category category)
    {
        return await _categoryDao.UpdateCategory(id, category);
    }

    public async Task<Category> DeleteCategory(int id)
    {
        return await _categoryDao.DeleteCategory(id);
    }
}