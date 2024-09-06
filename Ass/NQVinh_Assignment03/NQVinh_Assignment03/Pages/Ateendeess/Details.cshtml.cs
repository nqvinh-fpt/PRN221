using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace NQVinh_Assignment03.Pages.Ateendeess
{
    public class DetailsModel : PageModel
    {
        private readonly PRN_Ass3Context _context;

        public DetailsModel(PRN_Ass3Context context)
        {
            _context = context;
        }

        public Attendee Attendee { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Attendees == null)
            {
                return NotFound();
            }

            var attendee = await _context.Attendees.FirstOrDefaultAsync(m => m.AttendeeId == id);
            if (attendee == null)
            {
                return NotFound();
            }
            else
            {
                Attendee = attendee;
            }
            return Page();
        }
    }
}
