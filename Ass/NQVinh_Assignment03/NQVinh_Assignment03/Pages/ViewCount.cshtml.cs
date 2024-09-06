using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace NQVinh_Assignment03.Pages
{
    public class ViewCountModel : PageModel
    {
        private readonly PRN_Ass3Context _context;

        public ViewCountModel(PRN_Ass3Context context)
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
