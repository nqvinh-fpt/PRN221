using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Vinh.Hubs;
using WebApplication1.Models;

namespace NQVinh_Assignment03.Pages.Events
{
    public class DeleteModel : PageModel
    {
        private readonly PRN_Ass3Context _context;
        private readonly IHubContext<SignalRServer> _signalRHub;
        public DeleteModel(PRN_Ass3Context context, IHubContext<SignalRServer> signalRHub)
        {
            _context = context;
            _signalRHub = signalRHub;
        }

        [BindProperty]
        public Event Event { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Events == null)
            {
                return NotFound();
            }

            var selectedEvent = await _context.Events.FirstOrDefaultAsync(m => m.EventId == id);

            if (selectedEvent == null)
            {
                return NotFound();
            }
            else
            {
                Event = selectedEvent;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Events == null)
            {
                return NotFound();
            }

            var selectedEvent = await _context.Events.FindAsync(id);

            if (selectedEvent != null)
            {
                Event = selectedEvent;
                _context.Events.Remove(Event);
                await _context.SaveChangesAsync();
                await _signalRHub.Clients.All.SendAsync("LoadEvents");
            }

            return RedirectToPage("./Index");
        }
    }
}
