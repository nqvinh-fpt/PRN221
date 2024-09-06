using Ha.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Ha.Pages
{
    public class SignUpModel : PageModel
    {
        private readonly EventManagementDB0Context _context;

        public SignUpModel(EventManagementDB0Context context)
        {
            _context = context;
        }

        [BindProperty]
        public User Input { get; set; }

        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Thêm người dùng vào cơ sở dữ liệu
            _context.Users.Add(Input);
            await _context.SaveChangesAsync();

            // Chuyển hướng sau khi đăng ký thành công, kèm theo thông điệp xác nhận
            TempData["SuccessMessage"] = "Registration successful!";
            return RedirectToPage("/Requirement1/Event");
        }
    }
}