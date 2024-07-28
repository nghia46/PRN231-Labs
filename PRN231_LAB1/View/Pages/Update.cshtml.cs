using System.Text.Json;
using BusinisseObjects.Dto;
using BusinisseObjects.Dto.Response;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace View.Pages
{
    public class Update : PageModel
    {
        private readonly HttpClient _httpClient;

        public Update(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }

        [BindProperty] public ProductRequestDto ProductRequestDto { get; set; }

        [BindProperty] public ProductResponseDto ProductResponseDto { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            var apiUri = $"http://localhost:5050/api/Test/GetProductById/{id}";
            var response = await _httpClient.GetAsync(apiUri);            
            var responseStream = await response.Content.ReadAsStreamAsync();
            
            var options = new JsonSerializerOptions {PropertyNameCaseInsensitive = true};
            
            
            ProductResponseDto = await JsonSerializer.DeserializeAsync<ProductResponseDto>(responseStream, options);
            
            
            return Page();
            
        }
    }
}