using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace NQVinh_Assignment03.Pages.Ateendeess
{
    public class DeleteModel : PageModel
    {
        private readonly PRN_Ass3Context _context;

        public DeleteModel(PRN_Ass3Context context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Attendees == null)
            {
                return NotFound();
            }
            var attendee = await _context.Attendees.FindAsync(id);

            if (attendee != null)
            {
                Attendee = attendee;
                _context.Attendees.Remove(Attendee);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
