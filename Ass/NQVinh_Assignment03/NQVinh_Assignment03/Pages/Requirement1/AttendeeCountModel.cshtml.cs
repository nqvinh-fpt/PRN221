using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace NQVinh_Assignment03.Pages.Requirement1
{
    public class AttendeeCountModelModel : PageModel
    {
        public int TotalAttendees { get; set; }

        public void OnGet()
        {
            // L?y t?ng s? l??ng ng??i tham d? t? c? s? d? li?u ho?c b?t k? ngu?n d? li?u n�o kh�c
            TotalAttendees = 50; // V� d?: Thay 50 b?ng gi� tr? th?c t?
        }
    }
}
