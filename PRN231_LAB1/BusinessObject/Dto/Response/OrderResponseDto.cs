namespace BusinisseObjects.Dto.Response;

public class OrderResponseDto
{
    public required string OrderId { get; set; }
    public required string MemberId { get; set; }
    public DateTimeOffset OrderDate { get; set; }
    public DateTimeOffset RequiredDate { get; set; }
    public DateTimeOffset ShippedDate { get; set; }
    public string? Freight { get; set; }
}