using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Ha.Models;

namespace Ha.Pages.Attendeess
{
    public class DeleteModel : PageModel
    {
        private readonly Ha.Models.EventManagementDB0Context _context;

        public DeleteModel(Ha.Models.EventManagementDB0Context context)
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
