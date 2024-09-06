using Ha.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Ha.Pages.Requirement1
{
    public class ConfirmRequestsModel : PageModel
    {
        private readonly EventManagementDB0Context _context;

        public ConfirmRequestsModel(EventManagementDB0Context context)
        {
            _context = context;
        }

        public List<User> UserRequests { get; set; }

        public async Task OnGetAsync()
        {
            // Lấy danh sách người dùng mới cần xác nhận đăng ký từ cơ sở dữ liệu
            UserRequests = await _context.Users.ToListAsync();
        }
    }
}