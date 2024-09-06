using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Ha.Models;

namespace Ha.Pages.Events
{
    public class DepartmentNamePageModel : PageModel
    {
        public SelectList DepartmentNameSL { get; set; }
        public void PopulateDepartmentsDropDownList(EventManagementDB0Context _context,
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
