using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SupermarketWEB.Data;
using SupermarketWEB.Models;

namespace SupermarketWEB.Pages.PayModes
{
    public class EditModel : PageModel
    {
        private readonly SumermarketContext _context;

        public EditModel(SumermarketContext context)
        {
            _context = context;
        }

        [BindProperty]
        public PayMode PayModes { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.PayModes == null)
            {
                return NotFound();
            }

            var provider = await _context.PayModes.FirstOrDefaultAsync(m => m.Id == id);
            if (provider == null)
            {
                return NotFound();
            }
            PayModes = PayModes;
            return Page();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(PayModes).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }

            catch (DbUpdateConcurrencyException)
            {
                if (!ProductsExists(PayModes.Id))
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









