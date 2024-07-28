using BusinisseObjects;
using BusinisseObjects.Models;
using Microsoft.EntityFrameworkCore;
using Utils;

namespace Dao;

public class ProductDao
{
    private readonly AppDbContext _context = new();

    public async Task<IEnumerable<Product>> GetProducts()
    {
        return await _context.Products.ToListAsync();
    }
    public async Task<Product?> GetProductById(string id)
    {
        return await _context.Products.FindAsync(id);
    }
    public async Task<Product> AddProduct(Product product)
    {
        product.ProductId = Generator.IdGenerator();
        _context.Products.Add(product);
        await _context.SaveChangesAsync();
        return product;
    }
    public async Task<string> DeleteProduct(string id)
    {
        var product = await _context.Products.FindAsync(id);
        if (product == null)
        {
            return "Product not found";
        }
        _context.Products.Remove(product);
        await _context.SaveChangesAsync();
        return "Product deleted";
    }
    public async Task<Product?> UpdateProduct(string id, Product product)
    {
        var existingProduct = await _context.Products.FindAsync(id);
        if (existingProduct == null) return null;

        // Update properties individually except the primary key
        existingProduct.CategoryId = product.CategoryId;
        existingProduct.ProductName = product.ProductName;
        existingProduct.Weight = product.Weight;
        existingProduct.UnitPrice = product.UnitPrice;
        existingProduct.UnitsInStock = product.UnitsInStock;
        // Add any other properties that you want to update
    
        // Save the changes
        await _context.SaveChangesAsync();

        return existingProduct;
    }
}