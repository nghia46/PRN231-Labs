using BusinisseObjects;
using BusinisseObjects.Models;
using Microsoft.EntityFrameworkCore;
using Utils;

namespace Dao;

public class CategoryDao
{
    private readonly AppDbContext _context = new();
    
    public async Task<IEnumerable<Category>> GetCategories()
    {
        return await _context.Categories.ToListAsync();
    }
    public async Task<Category?> GetCategoryById(string id)
    {
        return await _context.Categories.FindAsync(id);
    }
    public async Task<Category> AddCategory(Category category)
    {
        category.CategoryId = Generator.IdGenerator();
        _context.Categories.Add(category);
        await _context.SaveChangesAsync();
        return category;
    }
    public async Task<string> DeleteCategory(string id)
    {
        var category = await _context.Categories.FindAsync(id);
        if (category == null)
        {
            return "Category not found";
        }
        _context.Categories.Remove(category);
        await _context.SaveChangesAsync();
        return "Category deleted";
    }
    public async Task<Category?> UpdateCategory(string id,Category category)
    {
        var existingCategory = await _context.Categories.FindAsync(id);
        if (existingCategory == null) return null;
        existingCategory.CategoryId = category.CategoryId;
        _context.Entry(existingCategory).CurrentValues.SetValues(category);
        _context.Entry(existingCategory).State = EntityState.Modified;
        return existingCategory;
    }
}