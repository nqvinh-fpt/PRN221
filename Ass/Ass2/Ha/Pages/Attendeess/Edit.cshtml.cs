using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Ha.Models;

namespace Ha.Pages.Attendeess
{
    public class EditModel : PageModel
    {
        private readonly Ha.Models.EventManagementDB0Context _context;

        public EditModel(Ha.Models.EventManagementDB0Context context)
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

            var attendee =  await _context.Attendees.FirstOrDefaultAsync(m => m.AttendeeId == id);
            if (attendee == null)
            {
                return NotFound();
            }
            Attendee = attendee;
           ViewData["EventId"] = new SelectList(_context.Events, "EventId", "EventId");
           ViewData["UserId"] = new SelectList(_context.Users, "UserId", "UserId");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Attendee).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AttendeeExists(Attendee.AttendeeId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool AttendeeExists(int id)
        {
          return (_context.Attendees?.Any(e => e.AttendeeId == id)).GetValueOrDefault();
        }
    }
}
