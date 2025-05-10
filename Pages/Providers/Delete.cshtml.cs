using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SupermarketWEB.Data;
using SupermarketWEB.Models;

namespace SupermarketWEB.Pages.Providers
{
    public class DeleteModel : PageModel
    {
        private readonly SumermarketContext _context;

        public DeleteModel(SumermarketContext context)
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
            else
            {
                Providers = Providers;
            }
            return Page();
        }
        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Providers == null)
            {
                return NotFound();
            }
            var product = await _context.Providers.FindAsync(id);
            if (product != null)
            {
                Providers = Providers;
                _context.Providers.Remove(Providers);
                await _context.SaveChangesAsync();
            }
            return RedirectToPage("./Index");
        }
    }
}