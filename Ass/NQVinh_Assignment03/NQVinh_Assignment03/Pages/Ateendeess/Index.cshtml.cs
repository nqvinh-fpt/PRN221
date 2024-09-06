using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace NQVinh_Assignment03.Pages.Ateendeess
{
    public class IndexModel : PageModel
    {
        private readonly PRN_Ass3Context _context;

        public IndexModel(PRN_Ass3Context context)
        {
            _context = context;
        }

        public IList<Attendee> Attendee { get; set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Attendees != null)
            {
                Attendee = await _context.Attendees
                .Include(a => a.Event)
                .Include(a => a.User).ToListAsync();
            }
        }
    }
}
