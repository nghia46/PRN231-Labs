using BusinisseObjects.Models;
using Dao;

namespace Repositoy;

public class CategoryRepository(CategoryDao categoryDao) : IGenericRepository<Category>
{
    private CategoryDao CategoryDao { get; } = categoryDao;

    public async Task<Category?> GetByIdAsync(string id)
    {
        return await CategoryDao.GetCategoryById(id);
    }

    public async Task<IEnumerable<Category>?> GetAllAsync()
    {
        return await CategoryDao.GetCategories();
    }

    public async Task<Category?> AddAsync(Category entity)
    {
        return await CategoryDao.AddCategory(entity);
    }

    public async Task<Category?> UpdateAsync(string id, Category entity)
    {
        return await CategoryDao.UpdateCategory(id, entity);
    }

    public async Task<string> DeleteAsync(string id)
    {
        return await CategoryDao.DeleteCategory(id);
    }
}