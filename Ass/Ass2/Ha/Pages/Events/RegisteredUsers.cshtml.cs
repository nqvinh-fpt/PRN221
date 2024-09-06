using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;
using Ha.Hubs; // Thêm using directive để sử dụng IUserService

namespace Ha.Pages.Events
{
    public class RegisteredUsersModel : PageModel
    {
        private readonly IUserService _userService;
        private readonly IHubContext<SignalRServer> _userUpdateHubContext;

        public RegisteredUsersModel(IUserService userService, IHubContext<SignalRServer> userUpdateHubContext)
        {
            _userService = userService;
            _userUpdateHubContext = userUpdateHubContext;
        }

        public async Task OnGetAsync()
        {
            int registeredUserCount = await _userService.GetRegisteredUserCount();

            // Gửi số lượng người dùng đã đăng ký thành công đến tất cả các client thông qua SignalR
            await _userUpdateHubContext.Clients.All.SendAsync("SendRegisteredUserCount", registeredUserCount);
        }
    }
}