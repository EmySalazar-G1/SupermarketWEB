using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Razor;
using SupermarketWEB.Data;
using SupermarketWEB.Models;

namespace SupermarketWEB.Pages.Products

{
    public class CreateModel : PageModel
    {
        private readonly SumermarketContext _context;
        public CreateModel(SumermarketContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }
        [BindProperty]
        public Product Products { get; set; } = default!;
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || _context.Products == null || Products == null)
            {
                return Page();
            }

            _context.Products.Add(Products);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
