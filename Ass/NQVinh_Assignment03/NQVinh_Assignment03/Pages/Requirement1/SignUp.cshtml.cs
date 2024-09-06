using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication1.Models;

namespace NQVinh_Assignment03.Pages.Requirement1
{
    public class SignUpModel : PageModel
    {
        private readonly PRN_Ass3Context _context;

        public SignUpModel(PRN_Ass3Context context)
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

            // Th�m ng??i d�ng v�o c? s? d? li?u
            _context.Users.Add(Input);
            await _context.SaveChangesAsync();

            // Chuy?n h??ng sau khi ??ng k� th�nh c�ng, k�m theo th�ng ?i?p x�c nh?n
            TempData["SuccessMessage"] = "Registration successful!";
            return RedirectToPage("/Requirement1/Event");
        }
    }
}
