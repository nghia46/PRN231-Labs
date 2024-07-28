using System.Text;
using System.Text.Json;
using BusinisseObjects.Dto.Request;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace View.Pages;

public class Login : PageModel
{
    private readonly HttpClient _httpClient;

    public Login(HttpClient httpClient)
    {
        _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
    }

    [BindProperty] public LoginRequestDto LoginRequest { get; set; }
    public string? ErrorMessage { get; set; }
    
    public void OnGet()
    {

    }
    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        var jsonRequest = JsonSerializer.Serialize(LoginRequest);
        var content = new StringContent(jsonRequest, Encoding.UTF8, "application/json");

        var response = await _httpClient.PostAsync("http://localhost:5050/api/Test/login", content);
        if (response.IsSuccessStatusCode)
        {
            var jsonResponse = await response.Content.ReadAsStringAsync();
            HttpContext.Session.SetString("UserEmail", jsonResponse);
            return RedirectToPage("/Product");
        }
        else
        {
            // Simulate login failure and add an error message to ViewData
            ViewData["ErrorMessage"] = "Invalid email or password.";
            return Page();
        }
    }
}