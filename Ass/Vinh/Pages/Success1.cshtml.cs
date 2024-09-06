using System.Threading.Tasks;
using Ha.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Ha.Pages
{
    public class Success1Model : PageModel
    {
        private readonly EventManagementDB0Context _context;

        public Success1Model(EventManagementDB0Context context)
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