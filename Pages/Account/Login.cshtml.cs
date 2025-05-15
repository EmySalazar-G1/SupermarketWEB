using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SupermarketWEB.Models;


namespace SupermarketWEB.Pages.Account
{
    public class LoginModel : PageModel

        {
            [BindProperty]
            public User User { get; set; }
            public void OnGet()
            {
            }
        }
    }
