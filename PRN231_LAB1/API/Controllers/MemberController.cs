using AutoMapper;
using BusinisseObjects.Dto.Request;
using BusinisseObjects.Dto.Response;
using Microsoft.AspNetCore.Mvc;
using Repositoy;
using Member = BusinisseObjects.Models.Member;

namespace API.Controllers;

[Controller]
[Route("api/[controller]")]
public class MemberController : ControllerBase
{
    private readonly IGenericRepository<Member> _repository;
    private readonly IMapper _mapper;

    public MemberController(IGenericRepository<Member> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    [HttpGet("GetMembers")]
    public async Task<IActionResult> Get()
    {
        var result = await _repository.GetAllAsync();
        if (result == null)
        {
            return NotFound();
        }
        var response = _mapper.Map<IEnumerable<MemberResponseDto>>(result);
        return Ok(response);
    }
    [HttpGet("GetMember/{id}")]
    public async Task<IActionResult> Get(string id)
    {
        var result = await _repository.GetByIdAsync(id);
        if (result == null)
        {
            return NotFound();
        }
        var response = _mapper.Map<MemberResponseDto>(result);
        return Ok(response);
    }
    [HttpPost("AddMember")]
    public async Task<IActionResult> Post([FromBody]MemberRequestDto member)
    {
        var result = await _repository.AddAsync(_mapper.Map<Member>(member));
        if (result == null)
        {
            return BadRequest();
        }
        var response = _mapper.Map<MemberResponseDto>(result);
        return Ok(response);
    }
    [HttpPut("UpdateMember")]
    public async Task<IActionResult> Put(string id,[FromBody]MemberRequestDto member)
    {
        var result = await _repository.UpdateAsync(id,_mapper.Map<Member>(member));
        
        if (result == null)
        {
            return BadRequest();
        }
        var response = _mapper.Map<MemberResponseDto>(result);
        return Ok(response);
    }
    [HttpDelete("DeleteMember/{id}")]
    public async Task<IActionResult> Delete(string id)
    {
        var result = await _repository.DeleteAsync(id);
        return Ok(result);
    }
}