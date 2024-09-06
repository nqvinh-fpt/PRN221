using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.SignalR;
using Vinh.Hubs;

namespace NQVinh_Assignment03.Pages.Events
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

            // G?i s? l??ng ng??i dùng ?ã ??ng ký thành công ??n t?t c? các client thông qua SignalR
            await _userUpdateHubContext.Clients.All.SendAsync("SendRegisteredUserCount", registeredUserCount);
        }
    }
}
