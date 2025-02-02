﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Text;
using System.Threading.Tasks;
using Ha.Models;

namespace Ha.Pages
{
    public class SignInModel : PageModel
    {
        private readonly EventManagementDB0Context _context;

        public SignInModel(EventManagementDB0Context context)
        {
            _context = context;
        }

        [BindProperty]
        public UserLogin Input { get; set; }

        public class UserLogin
        {
            public string Username { get; set; }
            public string Password { get; set; }
        }

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

            var user = await _context.Users.FirstOrDefaultAsync(u => u.Username == Input.Username && u.Password == Input.Password);

            if (user != null)
            {
                // Kiểm tra Role của người dùng và chuyển hướng tương ứng
                if (user.Role == "Admin")
                {
                    return RedirectToPage("/Events/Index");
                }
                else if (user.Role == "User")
                {
                    return RedirectToPage("/Requirement1/Event");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid role.");
                    return Page();
                }
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Invalid username or password.");
                return Page();
            }
        }
    }
}