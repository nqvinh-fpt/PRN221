using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.SignalR;
using Vinh.Hubs;
using WebApplication1.Models;

namespace NQVinh_Assignment03.Pages.Ateendeess
{
    public class CreateModel : PageModel
    {
        private readonly PRN_Ass3Context _context;

        private readonly IHubContext<SignalRServer> _signalRHub;

        public CreateModel(PRN_Ass3Context context, IHubContext<SignalRServer> signalRHub)
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

