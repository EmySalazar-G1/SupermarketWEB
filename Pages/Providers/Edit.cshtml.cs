using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SupermarketWEB.Data;
using SupermarketWEB.Models;

namespace SupermarketWEB.Pages.Providers
{ 
    public class EditModel : PageModel
    {
        private readonly SumermarketContext _context;

        public EditModel(SumermarketContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Provider Providers { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Providers == null)
            {
                return NotFound();
            }

            var provider = await _context.Providers.FirstOrDefaultAsync(m => m.Id == id);
            if (provider == null)
            {
                return NotFound();
            }
            Providers = provider;
            return Page();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Providers).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }

            catch (DbUpdateConcurrencyException)
            {
                if (!ProductsExists(Providers.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToPage("./Index");

        }
        private bool ProductsExists(int id)
        {
            return (_context.Providers?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}









