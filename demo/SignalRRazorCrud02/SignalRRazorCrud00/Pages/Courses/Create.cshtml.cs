using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.SignalR;
using SignalRRazorCrud00.Hubs;
using SignalRRazorCrud00.Models;

namespace SignalRRazorCrud00.Pages.Courses
{
    public class CreateModel : DepartmentNamePageModel
    {
        private readonly SignalRRazorCrud00.Models.SchoolContextDBContext _context;
        private readonly IHubContext<SignalRServer> _signalRHub;
        public CreateModel(SignalRRazorCrud00.Models.SchoolContextDBContext context, IHubContext<SignalRServer> signalRHub)
        {
            _context = context;
            _signalRHub= signalRHub;
        }

        public IActionResult OnGet()
        {
            PopulateDepartmentsDropDownList(_context);
            return Page();
        }

        [BindProperty]
        public Course Course { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            _context.Courses.Add(Course);
            await _context.SaveChangesAsync();
            PopulateDepartmentsDropDownList(_context, Course.DepartmentId);
            await _signalRHub.Clients.All.SendAsync("LoadCourses");
            return RedirectToPage("./Index");
        }
    }
}
/*
    var emptyCourse = new Course();

    if (await TryUpdateModelAsync<Course>(
         emptyCourse,
         "course",   // Prefix for form value.
         s => s.CourseId, s => s.DepartmentId, s => s.Title, s => s.Credits))
    {
        _context.Courses.Add(emptyCourse);
        await _context.SaveChangesAsync();
        await _signalRHub.Clients.All.SendAsync("LoadCourses");
        return RedirectToPage("./Index");
    }

    // Select DepartmentID if TryUpdateModelAsync fails.
    PopulateDepartmentsDropDownList(_context, emptyCourse.DepartmentId);
    return Page();
    */