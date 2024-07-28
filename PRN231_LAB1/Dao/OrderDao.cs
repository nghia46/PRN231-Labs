using BusinisseObjects;
using BusinisseObjects.Models;
using Microsoft.EntityFrameworkCore;
using Utils;

namespace Dao;

public class OrderDao
{
    private  readonly AppDbContext _context = new();
    
    public async Task<IEnumerable<Order>> GetOrders()
    {
        return await _context.Orders.ToListAsync();
    }
    
    public async Task<Order?> GetOrderById(string id)
    {
        return await _context.Orders.FindAsync(id);
    }
    
    public async Task<Order> AddOrder(Order order)
    {
        order.OrderId = Generator.IdGenerator();
        _context.Orders.Add(order);
        await _context.SaveChangesAsync();
        return order;
    }
    
    public async Task<string> DeleteOrder(string id)
    {
        var order = await _context.Orders.FindAsync(id);
        if (order == null)
        {
            return "Order not found";
        }
        _context.Orders.Remove(order);
        await _context.SaveChangesAsync();
        return "Order deleted";
    }
    
    public async Task<Order?> UpdateOrder(string id,Order order)
    {
        var existingOrder = await _context.Orders.FindAsync(id);
        if (existingOrder == null) return null;
        existingOrder.OrderDate = order.OrderDate;
        existingOrder.Freight = order.Freight;
        existingOrder.RequiredDate = order.RequiredDate;
        existingOrder.ShippedDate = order.ShippedDate;
        existingOrder.MemberId = order.MemberId;
        
        await _context.SaveChangesAsync();
        
        
        return existingOrder;
    }
}