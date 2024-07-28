using BussiniseObject.Models;
using Microsoft.EntityFrameworkCore;

namespace Dao;

public class CategoryDao
{
    private readonly ApplicationDbContext _context;

    public CategoryDao()
    {
        _context = new ApplicationDbContext();
    }
    public async Task<IEnumerable<Category>> GetCategories()
    {
        return await _context.Categories.ToListAsync();
    }

    public async Task<Category> GetCategoryById(int id)
    {
        return await _context.Categories.FindAsync(id);
    }
    public async Task<Category> AddCategory(Category category)
    {
        var lastCategory = await _context.Categories.OrderByDescending(x => x.CategoryId).FirstOrDefaultAsync();
        category.CategoryId = lastCategory.CategoryId + 1;
        _context.Categories.Add(category);
        await _context.SaveChangesAsync();
        return category;
    }
    public async Task<Category> UpdateCategory(int id,Category category)
    {
        var categoryUpdate = await _context.Categories.FindAsync(id);
        if (categoryUpdate == null)
        {
            return null;
        }
        categoryUpdate.CategoryName = category.CategoryName;
        await _context.SaveChangesAsync();
        return categoryUpdate;
    }
    public async Task<Category> DeleteCategory(int id)
    {
        var categoryDelete = await _context.Categories.FindAsync(id);
        if (categoryDelete == null)
        {
            return null;
        }
        _context.Categories.Remove(categoryDelete);
        await _context.SaveChangesAsync();
        return categoryDelete;
    }
}