using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Vinh.Hubs;
using WebApplication1.Models;

namespace NQVinh_Assignment03.Pages.Events
{
    public class EditModel : PageModel
    {
        private readonly PRN_Ass3Context _context;
        private readonly IHubContext<SignalRServer> _signalRHub;

        public EditModel(PRN_Ass3Context context, IHubContext<SignalRServer> signalRHub)
        {
            _context = context;
            _signalRHub = signalRHub;
        }

        [BindProperty]
        public Event Event { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Event = await _context.Events.FirstOrDefaultAsync(m => m.EventId == id);

            if (Event == null)
            {
                return NotFound();
            }

            ViewData["CategoryId"] = new SelectList(_context.EventCategories, "CategoryId", "CategoryId");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var eventToUpdate = await _context.Events.FindAsync(Event.EventId);

            if (eventToUpdate == null)
            {
                return NotFound();
            }

            if (await TryUpdateModelAsync<Event>(
                eventToUpdate,
                "Event",   // Prefix for form value.
                e => e.Title, e => e.Description, e => e.StartTime, e => e.EndTime, e => e.Location, e => e.CategoryId))
            {
                await _context.SaveChangesAsync();
                await _signalRHub.Clients.All.SendAsync("LoadEvents");
                return RedirectToPage("./Index");
            }

            // Select CategoryId if TryUpdateModelAsync fails.
            ViewData["CategoryId"] = new SelectList(_context.EventCategories, "CategoryId", "CategoryId", eventToUpdate.CategoryId);
            return Page();
        }

        private bool EventExists(int id)
        {
            return _context.Events.Any(e => e.EventId == id);
        }
    }
}
