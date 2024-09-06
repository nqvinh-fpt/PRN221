using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApplication1.Models;

namespace NQVinh_Assignment03.Pages.Events
{
    public class DepartmentNamePageModel : PageModel
    {
        public SelectList DepartmentNameSL { get; set; }
        public void PopulateDepartmentsDropDownList(PRN_Ass3Context _context,
            object selectedDepartment = null)
        {
            var departmentsQuery = from d in _context.Events
                                   orderby d.Title // Sort by name.
                                   select d;

            DepartmentNameSL = new SelectList(departmentsQuery,
                nameof(Event.EventId),
                nameof(Event.Title),
                selectedDepartment);
        }
    }
}
