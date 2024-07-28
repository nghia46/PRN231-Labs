using AutoMapper;
using BussiniseObject;
using BussiniseObject.Models;
using Microsoft.AspNetCore.Mvc;
using Repository;

namespace API.Controller;
[ApiController]
[Route("api/[controller]")]
public class CategoryController  : ControllerBase
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IMapper _mapper;
    public CategoryController(ICategoryRepository categoryRepository, IMapper mapper)
    {
        _categoryRepository = categoryRepository;
        _mapper = mapper;
    }
    [HttpGet("GetCategories")]
    public async Task<IActionResult> GetCategories()
    {
        var categories = await _categoryRepository.GetCategories();
        return Ok(categories);
    }
    [HttpGet("GetCategoryById/{id}")]
    public async Task<IActionResult> GetCategoryById(int id)
    {
        var category = await _categoryRepository.GetCategoryById(id);
        if (category == null)
        {
            return NotFound();
        }
        return Ok(category);
    }
    [HttpPost("AddCategory")]
    public async Task<IActionResult> AddCategory(CategoryDto categoryDto)
    {
        var category = _mapper.Map<Category>(categoryDto);
        var categoryAdd = await _categoryRepository.AddCategory(category);
        var result = _mapper.Map<CategoryDto>(categoryAdd);
        return Ok(result);
    }
    [HttpPut("UpdateCategory/{id}")]
    public async Task<IActionResult> UpdateCategory(int id, CategoryDto categoryDto)
    {
        var category = _mapper.Map<Category>(categoryDto);
        var categoryUpdate = await _categoryRepository.UpdateCategory(id, category);
        if (categoryUpdate == null)
        {
            return NotFound();
        }
        var result = _mapper.Map<CategoryDto>(categoryUpdate);
        return Ok(result);
    }
    [HttpDelete("DeleteCategory/{id}")]
    public async Task<IActionResult> DeleteCategory(int id)
    {
        var categoryDelete = await _categoryRepository.DeleteCategory(id);
        if (categoryDelete == null)
        {
            return NotFound();
        }
        var result = _mapper.Map<CategoryDto>(categoryDelete);
        return Ok(result);
    }
}