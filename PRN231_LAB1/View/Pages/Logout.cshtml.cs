using Microsoft.AspNetCore.Mvc.RazorPages;

namespace View.Pages;

public class Logout : PageModel
{
    public void OnGet()
    {
        HttpContext.Session.Remove("UserEmail");
        Response.Redirect("/Login");
    }
}