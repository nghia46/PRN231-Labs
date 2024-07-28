using System.Text;
using System.Text.Json;
using BusinisseObjects.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace View.Pages;

public class AddProduct : PageModel
{
    private readonly HttpClient _httpClient;

    public AddProduct(HttpClient httpClient)
    {
        _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
    }
    [BindProperty]
    public ProductRequestDto Product { get; set; }
    public void OnGet()
    {
        
    }
    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        // Serialize the Product object to JSON
        var jsonRequest = JsonSerializer.Serialize(Product);
        var content = new StringContent(jsonRequest, Encoding.UTF8, "application/json");

        // Replace with your API endpoint URL for adding a product
        var apiUrl = "http://localhost:5050/api/Test/AddProduct";

        // Send POST request to the API to add the product
        var response = await _httpClient.PostAsync(apiUrl, content);

        if (response.IsSuccessStatusCode)
        {
            // Optionally, handle success scenario
            // Redirect or return appropriate response
            return RedirectToPage("/Product"); // Example: Redirect to product list page after adding product
        }
        else
        {
            // Handle error scenario
            // For example, return a view with error message
            ModelState.AddModelError(string.Empty, "Failed to add product. Please try again.");
            return Page(); // Stay on the same page or return to another page as needed
        }
    }
}