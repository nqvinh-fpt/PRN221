using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication1.Models;

namespace NQVinh_Assignment03.Pages
{
    public class Success1Model : PageModel
    {
        private readonly PRN_Ass3Context _context;

        public Success1Model(PRN_Ass3Context context)
        {
            _context = context;
        }

        [BindProperty(SupportsGet = true)]
        public int EventId { get; set; }

        public Event Event { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            Event = await _context.Events.FindAsync(EventId);

            if (Event == null)
            {
                return NotFound();
            }

            return Page();
        }
    }
}
