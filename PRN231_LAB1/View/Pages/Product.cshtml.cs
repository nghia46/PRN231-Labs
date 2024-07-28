using System.Text;
using System.Text.Json;
using BusinisseObjects.Dto.Response;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace View.Pages;

public class Product : PageModel
{
    private readonly HttpClient _httpClient;

    public Product(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
    public IEnumerable<ProductResponseDto> Products { get; set; }
    [BindProperty]
    public string UserEmail { get; private set; }
    public async Task<IActionResult> OnGetAsync()
    {
        UserEmail = HttpContext.Session.GetString("UserEmail");
        
        if (string.IsNullOrEmpty(UserEmail))
        {
            return RedirectToPage("/Login");
        }
            
        var response = await _httpClient.GetAsync("http://localhost:5050/api/Test/GetProducts");
        if (!response.IsSuccessStatusCode) return Page();
        var responseStream = await response.Content.ReadAsStreamAsync();
        var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

        Products =
            await JsonSerializer.DeserializeAsync<IEnumerable<ProductResponseDto>>(responseStream, options) ??
            new List<ProductResponseDto>();

        return Page();
    }
}