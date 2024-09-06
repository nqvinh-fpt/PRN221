using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Ha.Models;

namespace Ha.Pages.Attendeess
{
    public class IndexModel : PageModel
    {
        private readonly Ha.Models.EventManagementDB0Context _context;

        public IndexModel(Ha.Models.EventManagementDB0Context context)
        {
            _context = context;
        }

        public IList<Attendee> Attendee { get;set; } = default!;

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
