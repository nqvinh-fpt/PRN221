using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Ha.Models;
using Ha.Hubs;
using Ha.Pages.Events;
using Microsoft.AspNetCore.SignalR;

namespace Ha
{
    public class CreateModel : DepartmentNamePageModel
    {
        private readonly EventManagementDB0Context _context;
        private readonly IHubContext<SignalRServer> _signalRHub;

        public CreateModel(EventManagementDB0Context context, IHubContext<SignalRServer> signalRHub)
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