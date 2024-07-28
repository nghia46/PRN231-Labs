namespace Repositoy;

public interface IGenericRepository<T> where T : class
{
    Task<T?> GetByIdAsync(string id);
    Task<IEnumerable<T>?> GetAllAsync();
    Task<T?> AddAsync(T entity);
    Task<T?> UpdateAsync(string id,T entity);
    Task<string> DeleteAsync(string id);
}