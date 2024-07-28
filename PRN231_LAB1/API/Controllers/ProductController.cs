using AutoMapper;
using BusinisseObjects.Dto;
using BusinisseObjects.Dto.Response;
using BusinisseObjects.Models;
using Microsoft.AspNetCore.Mvc;
using Repositoy;

namespace API.Controllers;
[Controller]
[Route("api/[controller]")]
public class ProductController : ControllerBase
{
    private readonly IGenericRepository<Product> _repository;   
    private readonly IMapper _mapper;

    public ProductController(IGenericRepository<Product> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    [HttpGet("GetProducts")]
    public async Task<IActionResult> Get()
    {
        var result = await _repository.GetAllAsync();
        if (result == null)
        {
            return NotFound();
        }
        var response = _mapper.Map<IEnumerable<ProductResponseDto>>(result);
        return Ok(response);
    }
    [HttpGet("GetProductById/{id}")]
    public async Task<IActionResult> Get(string id)
    {
        var result = await _repository.GetByIdAsync(id);
        if (result == null)
        {
            return NotFound();
        }
        var response = _mapper.Map<ProductResponseDto>(result);
        return Ok(response);
    }
    [HttpPost("AddProduct")]
    public async Task<IActionResult> Post([FromBody]ProductRequestDto product)
    {
        var entity = _mapper.Map<Product>(product);
        var response = await _repository.AddAsync(entity);
        return Ok(response);
    }
    [HttpPut("UpdateProduct")]
    public async Task<IActionResult> Put(string id,[FromBody]ProductRequestDto product)
    {
        var entity = _mapper.Map<Product>(product);
        var result = await _repository.UpdateAsync(id,entity);
        return Ok(result);
    }
    [HttpDelete("DeleteProduct/{id}")]
    public async Task<IActionResult> Delete(string id)
    {
        var result = await _repository.DeleteAsync(id);
        return Ok(result);
    }
}