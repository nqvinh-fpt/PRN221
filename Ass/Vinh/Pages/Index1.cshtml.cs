using Ha.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Ha.Pages
{
    public class Index1Model : PageModel
    {
        private readonly EventManagementDB0Context _context;

        public Index1Model(EventManagementDB0Context context)
        {
            _context = context;
        }

        public List<Event> Events { get; set; }
        public List<EventCategory> EventCategory { get; set; }

        public async Task OnGetAsync()
        {
           
            Events = await _context.Events.Include(e => e.Attendees).ToListAsync();

           
            Events = Events.OrderByDescending(e => e.Attendees.Count).ToList();
            EventCategory = await _context.EventCategories.Include( a => a.Events ).ToListAsync();




            EventCategory = EventCategory.OrderByDescending(a => a.Events.Count).ToList();
        }
    }
}
