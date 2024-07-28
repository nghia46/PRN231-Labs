using System.ComponentModel.DataAnnotations;

namespace BusinisseObjects.Models;

public class Member
{
    [MaxLength(7)]
    public required string MemberId { get; set; }
    [MaxLength(50)]
    public required string Email { get; set; }
    [MaxLength(50)]
    public required string Password { get; set; }
    [MaxLength(50)]
    public string? CompanyName { get; set; }
    [MaxLength(50)]
    public string? City { get; set; }
    [MaxLength(50)]
    public string? Country { get; set; }
    // Navigation properties
    public IEnumerable<Order>? Orders { get; set; }
}