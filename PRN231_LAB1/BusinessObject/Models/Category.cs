using System.ComponentModel.DataAnnotations;

namespace BusinisseObjects.Models;

public class Category
{
    [MaxLength(7)]
    public required string CategoryId { get; set; }
    [MaxLength(50)]
    public string? CategoryName { get; set; }
    // Navigation properties
    public IEnumerable<Product>? Products { get; set; }
}