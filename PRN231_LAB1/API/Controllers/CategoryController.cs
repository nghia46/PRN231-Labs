using BusinisseObjects.Models;
using Microsoft.AspNetCore.Mvc;
using Repositoy;

namespace API.Controllers;

[Controller]
[Route("api/[controller]")]
public class CategoryController : ControllerBase
{
    private readonly  IGenericRepository<Category> _repository;

    public CategoryController(IGenericRepository<Category> repository)
    {
        _repository = repository;
    }
    
    [HttpGet("GetCategories")]
    public async Task<IActionResult> Get()
    {
        var result = await _repository.GetAllAsync();
        if (result == null)
        {
            return NotFound();
        }
        return Ok(result);
    }
    [HttpGet("GetCategoryById/{id}")]
    public async Task<IActionResult> Get(string id)
    {
        var result = await _repository.GetByIdAsync(id);
        if (result == null)
        {
            return NotFound();
        }
        return Ok(result);
    }
    [HttpPost("AddCategory")]
    public async Task<IActionResult> Post([FromBody]Category request)
    {
        var result = await _repository.AddAsync(request);
        if (result == null)
        {
            return BadRequest();
        }
        return Ok(result);
    }
    [HttpPut("UpdateCategory/{id}")]
    public async Task<IActionResult> Put(string id, [FromBody]Category request)
    {
        var result = await _repository.UpdateAsync(id, request);
        if (result == null)
        {
            return BadRequest();
        }
        return Ok(result);
    }
    [HttpDelete("DeleteCategory/{id}")]
    public async Task<IActionResult> Delete(string id)
    {
        var result = await _repository.DeleteAsync(id);
        return Ok(result);
    }
}