using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Ha.Models;

namespace Ha
{
    public class IndexModel : PageModel
    {
        private readonly EventManagementDB0Context _context;

        public IndexModel(EventManagementDB0Context context)
        {
            _context = context;
        }
        public PaginatedList<Event> Events { get; set; }
        public string TitleSort { get; set; }
        public string StartTimeSort { get; set; }
        public string CategorySort { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }
        public string StartDateFilter { get; set; }
        public string EndDateFilter { get; set; }

        public async Task OnGetAsync(string sortOrder,
            string currentFilter, string searchString, string startDate, string endDate, int? pageIndex)
        {
            CurrentSort = sortOrder;
            TitleSort = String.IsNullOrEmpty(sortOrder) ? "title_desc" : "";
            StartTimeSort = sortOrder == "start_time" ? "start_time_desc" : "start_time";
            CategorySort = sortOrder == "category" ? "category_desc" : "category";

            if (searchString != null)
            {
                pageIndex = 1;
            }
            else
            {
                searchString = currentFilter;
            }
            CurrentFilter = searchString;

            IQueryable<Event> eventsIQ = from e in _context.Events
                                         select e;

            if (!String.IsNullOrEmpty(searchString))
            {
                eventsIQ = eventsIQ.Where(e => e.Title.Contains(searchString)
                                        || e.Description.Contains(searchString)
                                        || e.Location.Contains(searchString)
                                        || (e.StartTime.HasValue && e.StartTime.Value.ToString().Contains(searchString))
                                        || (e.EndTime.HasValue && e.EndTime.Value.ToString().Contains(searchString))
                                        || (e.Category != null && e.Category.CategoryName.Contains(searchString)));
            }

            if (!String.IsNullOrEmpty(startDate) && !String.IsNullOrEmpty(endDate))
            {
                DateTime startDateTime = DateTime.Parse(startDate);
                DateTime endDateTime = DateTime.Parse(endDate);
                eventsIQ = eventsIQ.Where(e => e.StartTime >= startDateTime && e.EndTime <= endDateTime);
            }

           
            
            switch (sortOrder)
            {
                case "title_desc":
                    eventsIQ = eventsIQ.OrderByDescending(e => e.Title);
                    break;
                case "start_time":
                    eventsIQ = eventsIQ.OrderBy(e => e.StartTime);
                    break;
                case "start_time_desc":
                    eventsIQ = eventsIQ.OrderByDescending(e => e.StartTime);
                    break;
                case "category":
                    eventsIQ = eventsIQ.OrderBy(e => e.Category.CategoryName);
                    break;
                case "category_desc":
                    eventsIQ = eventsIQ.OrderByDescending(e => e.Category.CategoryName);
                    break;
                default:
                    eventsIQ = eventsIQ.OrderBy(e => e.Title);
                    break;
            }

            const int pageSize = 5;
            Events = await PaginatedList<Event>.CreateAsync(
                eventsIQ.Include(e => e.Attendees).AsNoTracking(), pageIndex ?? 1, pageSize);

        }
    }
}