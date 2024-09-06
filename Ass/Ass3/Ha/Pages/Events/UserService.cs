using Ha.Models;
using Microsoft.EntityFrameworkCore;

namespace Ha.Pages.Events
{
    public class UserService : IUserService
    {
        private readonly EventManagementDB0Context _context;

        public UserService(EventManagementDB0Context context)
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
