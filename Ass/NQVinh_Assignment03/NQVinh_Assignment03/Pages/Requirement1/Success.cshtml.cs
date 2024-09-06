using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication1.Models;

namespace NQVinh_Assignment03.Pages.Requirement1
{
    public class SuccessModel : PageModel
    {
        private readonly PRN_Ass3Context _context;

        public SuccessModel(PRN_Ass3Context context)
        {
            _context = context;
        }

        public Event Event { get; set; }

        public async Task<IActionResult> OnGetAsync(int eventId)
        {
            Event = await _context.Events.FindAsync(eventId);

            if (Event == null)
            {
                return NotFound();
            }

            return Page();
        }
    }
}
