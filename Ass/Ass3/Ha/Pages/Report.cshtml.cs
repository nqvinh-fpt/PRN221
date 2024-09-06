using Ha.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Ha.Pages
{
    public class ReportModel : PageModel
    {
        private readonly EventManagementDB0Context _context;

        public ReportModel(EventManagementDB0Context context)
        {
            _context = context;
        }

        public List<Event> Events { get; set; }

        public async Task OnGetAsync()
        {
            Events = await _context.Events.Include(e => e.Attendees).ToListAsync();
        }
    }
}
