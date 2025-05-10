using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SupermarketWEB.Data;
using SupermarketWEB.Models;

namespace SupermarketWEB.Pages.PayModes
{
    public class DeleteModel : PageModel
    {
        private readonly SumermarketContext _context;

        public DeleteModel(SumermarketContext context)
        {
            _context = context;
        }
        [BindProperty]

        public PayMode PayMode{ get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.PayModes== null)
            {
                return NotFound();
            }
            var PayMode = await _context.PayModes.FirstOrDefaultAsync(m => m.Id == id);

            if (PayMode == null)
            {
                return NotFound();
            }
            else
            {
                PayMode = PayMode;
            }
            return Page();
        }
        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.PayModes == null)
            {
                return NotFound();
            }
            var payMode = await _context.PayModes.FindAsync(id); 

            if (payMode != null)
            {
                _context.PayModes.Remove(payMode); 
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }

    }
}