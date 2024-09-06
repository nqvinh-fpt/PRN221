using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace NQVinh_Assignment03.Pages
{
    public class ReportModel : PageModel
    {
        private readonly PRN_Ass3Context _context;

        public ReportModel(PRN_Ass3Context context)
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
