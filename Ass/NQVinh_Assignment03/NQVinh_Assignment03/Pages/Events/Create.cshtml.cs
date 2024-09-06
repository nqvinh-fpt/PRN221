using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.SignalR;
using Vinh.Hubs;
using WebApplication1.Models;

namespace NQVinh_Assignment03.Pages.Events
{
    public class CreateModel : PageModel
    {
        private readonly PRN_Ass3Context _context;
        private readonly IHubContext<SignalRServer> _signalRHub;

        public CreateModel(PRN_Ass3Context context, IHubContext<SignalRServer> signalRHub)
        {
            _context = context;
            _signalRHub = signalRHub;
        }

        public IActionResult OnGet()
        {
            PopulateCategoriesDropDownList();
            return Page();
        }

        [BindProperty]
        public Event Event { get; set; } = new Event();

        public SelectList CategoriesList { get; set; }

        private void PopulateCategoriesDropDownList()
        {
            CategoriesList = new SelectList(_context.EventCategories, "CategoryId", "CategoryName");
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                PopulateCategoriesDropDownList();
                return Page();
            }

            _context.Events.Add(Event);
            await _context.SaveChangesAsync();

            await _signalRHub.Clients.All.SendAsync("LoadEvents");

            return RedirectToPage("./Index");
        }
    }
}
