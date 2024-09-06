using Ha.Hubs;
using Ha.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ha.Pages.Requirement1
{
    public class EventViewModel
    {
        public Event Event { get; set; }
        public int AttendeeCount { get; set; }
    }

    public class EventModel : PageModel
    {
        private readonly EventManagementDB0Context _context;
        private readonly IHubContext<SignalRServer> _signalRHub;

        public EventModel(EventManagementDB0Context context, IHubContext<SignalRServer> signalRHub)
        {
            _context = context;
            _signalRHub = signalRHub;
        }

        public IList<EventViewModel> EventViewModels { get; set; }

        public async Task OnGetAsync()
        {
            // Lấy danh sách các sự kiện từ cơ sở dữ liệu
            var events = await _context.Events.ToListAsync();

            EventViewModels = new List<EventViewModel>();

            // Lặp qua từng sự kiện để tính toán số lượng người tham dự và thêm vào danh sách ViewModel
            foreach (var ev in events)
            {
                var attendeeCount = await _context.Attendees.Where(a => a.EventId == ev.EventId).CountAsync();
                var eventViewModel = new EventViewModel { Event = ev, AttendeeCount = attendeeCount };
                EventViewModels.Add(eventViewModel);

                // Gửi thông điệp đến SignalR Hub để cập nhật số lượng người tham dự cho sự kiện này
                await _signalRHub.Clients.All.SendAsync("updateAttendeeCount", ev.EventId, attendeeCount);
            }
        }
    }
}