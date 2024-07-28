using BusinisseObjects.Models;
using Dao;

namespace Repositoy;

public class OrderRepository(OrderDao orderDao) : IGenericRepository<Order>
{
    private OrderDao OrderDao { get; } = orderDao;

    public async Task<Order?> GetByIdAsync(string id)
    {
        return await OrderDao.GetOrderById(id);
    }

    public async Task<IEnumerable<Order>?> GetAllAsync()
    {
        return await OrderDao.GetOrders();
    }

    public async Task<Order?> AddAsync(Order entity)
    {
        return await OrderDao.AddOrder(entity);
    }

    public async Task<Order?> UpdateAsync(string id, Order entity)
    {
        return await OrderDao.UpdateOrder(id, entity);
    }

    public async Task<string> DeleteAsync(string id)
    {
        return await OrderDao.DeleteOrder(id);
    }
}