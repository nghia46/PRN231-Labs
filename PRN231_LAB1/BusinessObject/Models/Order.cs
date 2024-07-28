using System.ComponentModel.DataAnnotations;

namespace BusinisseObjects.Models;

public class Order
{
    [MaxLength(7)] public required string OrderId { get; set; }
    [MaxLength(7)] public required string MemberId { get; set; }
    public DateTimeOffset OrderDate { get; set; }
    public DateTimeOffset RequiredDate { get; set; }
    public DateTimeOffset ShippedDate { get; set; }
    [MaxLength(50)] public string? Freight { get; set; }
    // Navigation properties
    public Member? Member { get; set; }
    public IEnumerable<OrderDetail>? OrderDetails { get; set; }
}