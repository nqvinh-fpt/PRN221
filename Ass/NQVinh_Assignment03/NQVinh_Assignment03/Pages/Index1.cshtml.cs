using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace NQVinh_Assignment03.Pages
{
    public class Index1Model : PageModel
    {
        private readonly PRN_Ass3Context _context;

        public Index1Model(PRN_Ass3Context context)
        {
            _context = context;
        }

        public List<Event> Events { get; set; }
        public List<EventCategory> EventCategory { get; set; }

        public async Task OnGetAsync()
        {

            Events = await _context.Events.Include(e => e.Attendees).ToListAsync();


            Events = Events.OrderByDescending(e => e.Attendees.Count).ToList();
            EventCategory = await _context.EventCategories.Include(a => a.Events).ToListAsync();




            EventCategory = EventCategory.OrderByDescending(a => a.Events.Count).ToList();
        }
    }
}
