namespace BusinisseObjects.Dto.Request;

public class MemberRequestDto
{
    public required string Email { get; set; }
    public required string Password { get; set; }
    public string? CompanyName { get; set; }
    public string? City { get; set; }
    public string? Country { get; set; }
}