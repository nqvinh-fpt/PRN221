﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPageLab2.Data;
using RazorPageLab2.Models;

namespace RazorPageLab2.Pages.Students
{
    public class DetailsModel : PageModel
    {
        private readonly RazorPageLab2.Data.SchoolContext _context;

        public DetailsModel(RazorPageLab2.Data.SchoolContext context)
        {
            _context = context;
        }

        public Student Student { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Students == null)
            {
                return NotFound();
            }

            //var student = await _context.Students.FirstOrDefaultAsync(m => m.ID == id);
            var student = await _context.Students
                            .Include(s => s.Enrollments)
                            .ThenInclude(e => e.Course)
                            .AsNoTracking()
                            .FirstOrDefaultAsync(m => m.ID == id);
            if (student == null)
            {
                return NotFound();
            }
            else
            {
                Student = student;
            }
            return Page();
        }
    }
}
