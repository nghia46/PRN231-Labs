using BusinisseObjects.Models;
using Dao;

namespace Repositoy;

public class ProductRepository(ProductDao productDao) : IGenericRepository<Product>
{
    private ProductDao ProductDao { get; } = productDao;

    public async Task<Product?> GetByIdAsync(string id)
    {
        return await ProductDao.GetProductById(id);
    }

    public async Task<IEnumerable<Product>?> GetAllAsync()
    {
        return await ProductDao.GetProducts();
    }

    public async Task<Product?> AddAsync(Product entity)
    {
        return await ProductDao.AddProduct(entity);
    }

    public async Task<Product?> UpdateAsync(string id, Product entity)
    {
        return await ProductDao.UpdateProduct(id, entity);
    }


    public Task<string> DeleteAsync(string id)
    {
        return ProductDao.DeleteProduct(id);
    }
}