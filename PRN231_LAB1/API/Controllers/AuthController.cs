using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using BusinisseObjects;
using BusinisseObjects.Dto.Request;

namespace API.Controllers;

[Controller]
[Route("api/[controller]")]
public class AuthController(IMapper mapper) : ControllerBase
{
    private IMapper Mapper { get; } = mapper;
    private readonly AppDbContext _context = new();
    
    [HttpPost("login")]
    public IActionResult Login([FromBody] LoginRequestDto request)
    {
        var user = _context.Members.FirstOrDefault(x => x.Email == request.Email && x.Password == request.Password);
        if (user == null)
        {
            return BadRequest("Invalid email or password");
        }

        return Ok(user.Email);
    }
}