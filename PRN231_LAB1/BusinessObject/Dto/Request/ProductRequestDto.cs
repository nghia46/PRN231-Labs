namespace BusinisseObjects.Dto;

public class ProductRequestDto
{
    public string? ProductName { get; set; }
    public required string CategoryId { get; set; }
    public float Weight { get; set; }
    public float UnitPrice { get; set; }
    public int UnitsInStock { get; set; }
}