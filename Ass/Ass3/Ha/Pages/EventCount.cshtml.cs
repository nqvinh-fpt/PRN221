using Ha.Hubs;
using Ha.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;

namespace Ha.Pages
{
    public class EventCountModel : PageModel
    {
        private readonly EventManagementDB0Context _context;
        private readonly IHubContext<SignalRServer> _userUpdateHubContext;
        public EventCountModel(EventManagementDB0Context context, IHubContext<SignalRServer> userUpdateHubContext)
        {
            _context = context;
            _userUpdateHubContext = userUpdateHubContext;
        }

        public int TotalEvents { get; set; }
        public int TotalAttendees { get; set; }

        public async Task OnGetAsync()
        {
            // Đếm số lượng sự kiện
            TotalEvents = await _context.Events.CountAsync();

            // Đếm số lượng người tham dự toàn bộ sự kiện
            TotalAttendees = await _context.Attendees.CountAsync();
        }
    }
}