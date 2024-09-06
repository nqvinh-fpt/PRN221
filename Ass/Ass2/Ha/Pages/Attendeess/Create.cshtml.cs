using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Ha.Models;
using Ha.Hubs;
using Microsoft.AspNetCore.SignalR;

namespace Ha.Pages.Attendeess
{
    public class CreateModel : PageModel
    {
        private readonly Ha.Models.EventManagementDB0Context _context;

        private readonly IHubContext<SignalRServer> _signalRHub;

        public CreateModel(EventManagementDB0Context context, IHubContext<SignalRServer> signalRHub)
        {
            _context = context;
            _signalRHub = signalRHub;
        }

        public IActionResult OnGet()
        {
        ViewData["EventId"] = new SelectList(_context.Events, "EventId", "EventId");
        ViewData["UserId"] = new SelectList(_context.Users, "UserId", "UserId");
            return Page();
        }

        [BindProperty]
        public Attendee Attendee { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Attendees == null || Attendee == null)
            {
                return Page();
            }

            _context.Attendees.Add(Attendee);
            await _context.SaveChangesAsync();
            await _signalRHub.Clients.All.SendAsync("LoadEvents");
            return RedirectToPage("./Index");
        }
    }
}
