using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace NQVinh_Assignment03.Pages.Events
{
    public class UserService : IUserService
    {
        private readonly PRN_Ass3Context _context;

        public UserService(PRN_Ass3Context context)
        {
            _context = context;
        }

        public async Task<int> GetRegisteredUserCount()
        {
            // Logic để lấy số lượng người dùng đã đăng ký thành công từ cơ sở dữ liệu hoặc nguồn dữ liệu khác
            // Ví dụ:
            var registeredUserCount = await _context.Users.CountAsync();
            return registeredUserCount;
        }
    }
}
