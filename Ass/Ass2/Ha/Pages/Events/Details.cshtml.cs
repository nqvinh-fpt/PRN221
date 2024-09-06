using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Ha.Models;

namespace Ha
{
    public class DetailsModel : PageModel
    {
        private readonly EventManagementDB0Context _context;

        public DetailsModel(EventManagementDB0Context context)
        {
            _context = context;
        }

        public Event Event { get; set; }
        public EventCategory EventCategory { get; set; } // Thêm thuộc tính EventCategory

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Events == null)
            {
                return NotFound();
            }

            var selectedEvent = await _context.Events
                .Include(e => e.Category) // Include EventCategory
                .FirstOrDefaultAsync(m => m.EventId == id);

            if (selectedEvent == null)
            {
                return NotFound();
            }
            else
            {
                Event = selectedEvent;
                EventCategory = selectedEvent.Category; // Gán EventCategory
            }
            return Page();
        }
    }
}