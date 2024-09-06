using Ha.Hubs;
using Ha.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace Ha.Pages
{
    public class RegisterModel : PageModel
    {
        private readonly EventManagementDB0Context _context;
        private readonly IHubContext<SignalRServer> _userUpdateHubContext;

        [BindProperty]
        public Attendee Attendee { get; set; }

        public RegisterModel(EventManagementDB0Context context, IHubContext<SignalRServer> userUpdateHubContext)
        {
            _context = context;
            _userUpdateHubContext = userUpdateHubContext;
        }

        public IActionResult OnGet(int eventId)
        {
            Attendee = new Attendee { EventId = eventId };
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Attendee.RegistrationTime = DateTime.Now;

            try
            {
                _context.Attendees.Add(Attendee);
                await _context.SaveChangesAsync();

                
                var attendeeCount = await _context.Attendees.CountAsync(a => a.EventId == Attendee.EventId);

               
                await _userUpdateHubContext.Clients.All.SendAsync("LoadEvents");
            }
            catch (Exception)
            {
                return RedirectToPage("/Error");
            }

            return RedirectToPage("/Requirement1/Event");
        }
    }
}