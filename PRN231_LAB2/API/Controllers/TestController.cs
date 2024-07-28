using BusinessObject;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;
[ApiController]
[Route("api/[controller]")]
public class TestController : ControllerBase
{
    private readonly AppDbContext _context;

    public TestController()
    {
        _context = new AppDbContext();
    
    }
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var authors = await _context.Authors.ToListAsync();
        return Ok(authors);
    }
}