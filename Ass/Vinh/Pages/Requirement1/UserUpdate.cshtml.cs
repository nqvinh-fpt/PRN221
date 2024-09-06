using Ha.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Ha.Pages.Requirement1
{
    public class UserUpdateModel : PageModel
    {
        private readonly EventManagementDB0Context _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserUpdateModel(EventManagementDB0Context context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        [BindProperty]
        public User User { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            // Lấy UserId từ session
            int userId = _httpContextAccessor.HttpContext.Session.GetInt32("UserId") ?? 0;

            // Truy vấn thông tin người dùng từ cơ sở dữ liệu dựa trên UserId
            User = await _context.Users.FindAsync(userId);

            if (User == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(User).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(User.UserId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("/Profile");
        }

        private bool UserExists(int userId)
        {
            return _context.Users.Any(e => e.UserId == userId);
        }
    }
}

