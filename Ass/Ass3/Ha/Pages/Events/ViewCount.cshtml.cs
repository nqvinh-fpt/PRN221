using Ha.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ha.Pages.Events
{
    public class IndexModel : PageModel
    {
        private readonly EventManagementDB0Context _context;

        public IndexModel(EventManagementDB0Context context)
        {
            _context = context;
        }

        public List<Event> Events { get; set; }

        public async Task OnGetAsync()
        {
            // Lấy danh sách các sự kiện và số lượng người tham dự cho mỗi sự kiện
            Events = await _context.Events.Include(e => e.Attendees).ToListAsync();

            // Sắp xếp danh sách sự kiện theo số lượng người tham dự (giảm dần)
            Events = Events.OrderByDescending(e => e.Attendees.Count).ToList();
        }
    }
}