using AutoMapper;
using BusinisseObjects.Dto.Request;
using BusinisseObjects.Dto.Response;
using BusinisseObjects.Models;
using Microsoft.AspNetCore.Mvc;
using Repositoy;

namespace API.Controllers;

[Controller]
[Route("api/[controller]")]
public class OrderController : ControllerBase
{
    private readonly  IGenericRepository<Order> _repository;
    private readonly IMapper _mapper;

    public OrderController(IGenericRepository<Order> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    
    [HttpGet("GetOrders")]
    public async Task<IActionResult> Get()
    {
        var result = await _repository.GetAllAsync();
        if (result == null)
        {
            return NotFound();
        }
        var response = _mapper.Map<IEnumerable<OrderResponseDto>>(result);
        return Ok(response);
    }
    [HttpGet("GetOrderById/{id}")]
    public async Task<IActionResult> Get(string id)
    {
        var result = await _repository.GetByIdAsync(id);
        if (result == null)
        {
            return NotFound();
        }
        var response = _mapper.Map<OrderResponseDto>(result);
        return Ok(response);
    }
    [HttpPost("AddOrder")]
    public async Task<IActionResult> Post([FromBody]OrderRequestDto request)
    {
        var order = _mapper.Map<Order>(request);
        var result = await _repository.AddAsync(order);
        if (result == null)
        {
            return BadRequest();
        }
        var response = _mapper.Map<OrderResponseDto>(result);
        return Ok(response);
    }
    [HttpPut("UpdateOrder/{id}")]
    public async Task<IActionResult> Put(string id, [FromBody]OrderRequestDto request)
    {
        var order = _mapper.Map<Order>(request);
        var result = await _repository.UpdateAsync(id, order);
        if (result == null)
        {
            return BadRequest();
        }
        var response = _mapper.Map<OrderResponseDto>(result);
        return Ok(response);
    }
    [HttpDelete("DeleteOrder/{id}")]
    public async Task<IActionResult> Delete(string id)
    {
        var result = await _repository.DeleteAsync(id);
        return Ok(result);
    }
}