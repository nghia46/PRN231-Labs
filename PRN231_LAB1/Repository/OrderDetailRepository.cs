using BusinisseObjects.Models;
using Dao;

namespace Repositoy;

public class OrderDetailRepository(OrderDetailDao orderDetailDao) : IGenericRepository<OrderDetail>
{
    public OrderDetailDao OrderDetailDao { get; } = orderDetailDao;


    public async Task<OrderDetail?> GetByIdAsync(string id)
    {
        return await OrderDetailDao.GetOrderDetailById(id);
    }

    public async Task<IEnumerable<OrderDetail>?> GetAllAsync()
    {
        return await OrderDetailDao.GetOrderDetails();
    }

    public async Task<OrderDetail?> AddAsync(OrderDetail entity)
    {
        return await OrderDetailDao.AddOrderDetail(entity);
    }

    public async Task<OrderDetail?> UpdateAsync(string id, OrderDetail entity)
    {
        return await OrderDetailDao.UpdateOrderDetail(id, entity);
    }

    public async Task<string> DeleteAsync(string id)
    {
        return await OrderDetailDao.DeleteOrderDetail(id);
    }
}