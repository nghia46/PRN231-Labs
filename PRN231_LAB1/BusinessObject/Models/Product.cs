using System.ComponentModel.DataAnnotations;

namespace BusinisseObjects.Models;

public class Product
{
    [MaxLength(7)]
    public required string ProductId { get; set; }
    [MaxLength(50)]
    public string? ProductName { get; set; }
    [MaxLength(7)]
    public required string CategoryId { get; set; }
    public float Weight { get; set; }
    public float UnitPrice { get; set; }
    public int UnitsInStock { get; set; }
    
    // Navigation properties
    public Category? Category { get; set; }
    public IEnumerable<OrderDetail>? OrderDetails { get; set; }
}