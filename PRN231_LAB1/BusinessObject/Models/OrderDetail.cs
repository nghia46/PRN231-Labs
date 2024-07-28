using System.ComponentModel.DataAnnotations;

namespace BusinisseObjects.Models;

public class OrderDetail
{
    [MaxLength(7)]
    public required string OrderId { get; set; }
    [MaxLength(7)]
    public required string ProductId { get; set; }
    public float UnitPrice { get; set; }
    public int Quantity { get; set; }
    public int Discount { get; set; }
    // Navigation properties
    public Order? Order { get; set; }
    public Product? Product { get; set; }
}