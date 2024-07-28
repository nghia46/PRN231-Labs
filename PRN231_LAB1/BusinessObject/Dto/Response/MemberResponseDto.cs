namespace BusinisseObjects.Dto.Response;

public class MemberResponseDto
{
    public required string MemberId { get; set; }
    public required string Email { get; set; }
    public required string Password { get; set; }
    public string? CompanyName { get; set; }
    public string? City { get; set; }
    public string? Country { get; set; }
}