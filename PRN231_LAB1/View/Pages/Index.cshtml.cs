using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace View.Pages
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public string UserEmail { get; private set; }
        public IndexModel()
        {
            
        }
        public void OnGet()
        {
            UserEmail = HttpContext.Session.GetString("UserEmail");
        }
    }
}