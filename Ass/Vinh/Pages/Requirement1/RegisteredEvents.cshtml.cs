using Ha.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Ha.Pages.Requirement1
{
    public class RegisteredEventsModel : PageModel
    {
        private readonly EventManagementDB0Context _context;

        public RegisteredEventsModel(EventManagementDB0Context context)
        {
            _context = context;
        }

        public List<Event> RegisteredEvents { get; private set; }

        public void OnGet()
        {
            // Lấy UserId từ Session
            var userId = HttpContext.Session.GetString("UserId");

            if (userId != null)
            {
                int userIdInt;
                if (int.TryParse(userId, out userIdInt))
                {
                    // Lấy danh sách sự kiện đã đăng ký của người dùng từ cơ sở dữ liệu
                    RegisteredEvents = _context.Attendees
                        .Where(a => a.UserId == userIdInt)
                        .Select(a => a.Event)
                        .ToList();
                }
                else
                {
                    // Nếu không thể chuyển đổi UserId thành số nguyên, gán danh sách sự kiện đã đăng ký là rỗng
                    RegisteredEvents = new List<Event>();
                }
            }
            else
            {
                // Nếu không có UserId trong Session, gán danh sách sự kiện đã đăng ký là rỗng
                RegisteredEvents = new List<Event>();
            }
        }
    }
}