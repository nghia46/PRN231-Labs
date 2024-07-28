using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace View.Pages;

public class Delete : PageModel
{
    private readonly HttpClient _httpClient;

    public Delete(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<IActionResult> OnPostAsync(string id)
    {
        // Replace with your API endpoint URL for deleting a product
        var apiUrl = $"http://localhost:5050/api/Test/DeleteProduct/{id}";

        // Send DELETE request to the API
        var response = await _httpClient.DeleteAsync(apiUrl);

        if (response.IsSuccessStatusCode)
        {
            // Optionally, handle success scenario
            // Redirect or return appropriate response
            return RedirectToPage("/Product"); // Example: Redirect to product list page after deletion
        }
        else
        {
            // Handle error scenario
            // For example, return a view with error message
            return Page(); // Stay on the same page or return to another page as needed
        }
    }

}