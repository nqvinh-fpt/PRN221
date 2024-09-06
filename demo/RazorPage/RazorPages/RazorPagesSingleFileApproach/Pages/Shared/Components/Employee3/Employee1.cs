using Microsoft.AspNetCore.Mvc;

namespace RazorPagesSingleFileApproach.Pages.Shared.Components.Student
{
    [ViewComponent]
    public class Employee1
    {
        public string Invoke()
        {
            return "Use [ViewComponent]";
        }
    }
}
