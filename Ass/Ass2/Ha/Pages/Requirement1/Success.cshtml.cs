using Ha.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Ha.Pages.Requirement1
{
    public class SuccessModel : PageModel
    {
        private readonly EventManagementDB0Context _context;

        public SuccessModel(EventManagementDB0Context context)
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