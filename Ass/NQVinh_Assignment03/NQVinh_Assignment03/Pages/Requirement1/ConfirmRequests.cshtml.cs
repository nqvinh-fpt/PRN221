using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace NQVinh_Assignment03.Pages.Requirement1
{
    public class ConfirmRequestsModel : PageModel
    {
        private readonly PRN_Ass3Context _context;

        public ConfirmRequestsModel(PRN_Ass3Context context)
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
