using BusinisseObjects;
using BusinisseObjects.Models;
using Microsoft.EntityFrameworkCore;
using Utils;

namespace Dao;

public class OrderDetailDao
{
    private readonly AppDbContext _context = new();
    
    public async Task<IEnumerable<OrderDetail>> GetOrderDetails()
    {
        return await _context.OrderDetails.ToListAsync();
    }
    public async Task<OrderDetail?> GetOrderDetailById(string id)
    {
        return await _context.OrderDetails.FindAsync(id);
    }
    public async Task<OrderDetail> AddOrderDetail(OrderDetail orderDetail)
    {
        _context.OrderDetails.Add(orderDetail);
        await _context.SaveChangesAsync();
        return orderDetail;
    }
    public async Task<string> DeleteOrderDetail(string id)
    {
        var orderDetail = await _context.OrderDetails.FindAsync(id);
        if (orderDetail == null)
        {
            return "OrderDetail not found";
        }
        _context.OrderDetails.Remove(orderDetail);
        await _context.SaveChangesAsync();
        return "OrderDetail deleted";
    }
    public async Task<OrderDetail?> UpdateOrderDetail(string id,OrderDetail orderDetail)
    {
        var existingOrderDetail = await _context.OrderDetails.FindAsync(id);
        if (existingOrderDetail == null) return null;
        existingOrderDetail.ProductId = orderDetail.ProductId;
        existingOrderDetail.OrderId = orderDetail.OrderId;
        _context.Entry(existingOrderDetail).CurrentValues.SetValues(orderDetail);
        _context.Entry(existingOrderDetail).State = EntityState.Modified;
        return existingOrderDetail;
    }
}
    