using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Ha.Pages.Requirement1
{
    public class AttendeeCountModel : PageModel
    {
        public int TotalAttendees { get; set; }

        public void OnGet()
        {
            // Lấy tổng số lượng người tham dự từ cơ sở dữ liệu hoặc bất kỳ nguồn dữ liệu nào khác
            TotalAttendees = 50; // Ví dụ: Thay 50 bằng giá trị thực tế
        }
    }
}