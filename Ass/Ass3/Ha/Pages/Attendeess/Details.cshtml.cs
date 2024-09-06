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
    public class DetailsModel : PageModel
    {
        private readonly Ha.Models.EventManagementDB0Context _context;

        public DetailsModel(Ha.Models.EventManagementDB0Context context)
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
