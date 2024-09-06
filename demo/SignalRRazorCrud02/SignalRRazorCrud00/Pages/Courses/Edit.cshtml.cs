using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using SignalRRazorCrud00.Hubs;
using SignalRRazorCrud00.Models;

namespace SignalRRazorCrud00.Pages.Courses
{
    public class EditModel : DepartmentNamePageModel
    {
        private readonly SignalRRazorCrud00.Models.SchoolContextDBContext _context;
        private readonly IHubContext<SignalRServer> _signalRHub;
        public EditModel(SignalRRazorCrud00.Models.SchoolContextDBContext context, IHubContext<SignalRServer> signalRHub)
        {
            _context = context;
            _signalRHub = signalRHub;
        }

        [BindProperty]
        public Course Course { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Courses == null)
            {
                return NotFound();
            }

            var course =  await _context.Courses.Include(c => c.Department).FirstOrDefaultAsync(m => m.CourseId == id);
            if (course == null)
            {
                return NotFound();
            }
            Course = course;
            PopulateDepartmentsDropDownList(_context, Course.DepartmentId);
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var courseToUpdate = await _context.Courses.FindAsync(id);

            if (courseToUpdate == null)
            {
                return NotFound();
            }

            if (await TryUpdateModelAsync<Course>(
                 courseToUpdate,
                 "course",   // Prefix for form value.
                   c => c.Credits, c => c.DepartmentId, c => c.Title))
            {
                await _context.SaveChangesAsync();
                await _signalRHub.Clients.All.SendAsync("LoadCourses");
                return RedirectToPage("./Index");
            }

            // Select DepartmentID if TryUpdateModelAsync fails.
            PopulateDepartmentsDropDownList(_context, courseToUpdate.DepartmentId);
            return Page();
        }

        private bool CourseExists(int id)
        {
          return _context.Courses.Any(e => e.CourseId == id);
        }
    }
}
