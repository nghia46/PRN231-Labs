namespace BusinisseObjects.Dto.Request;

public class OrderRequestDto
{
    public required string MemberId { get; set; }
    public DateTimeOffset OrderDate { get; set; }
    public DateTimeOffset RequiredDate { get; set; }
    public DateTimeOffset ShippedDate { get; set; }
    public string? Freight { get; set; }
}