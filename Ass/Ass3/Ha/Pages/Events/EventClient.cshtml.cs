using Ha.Hubs;
using Ha.Models;
using Ha.Pages.Requirement1;
using Ha;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;

namespace Ha.Pages.Events
{
    

public class EventClientModel : PageModel
{
    private readonly EventManagementDB0Context _context;
    private readonly IHubContext<SignalRServer> _signalRHub;

    public EventClientModel(EventManagementDB0Context context, IHubContext<SignalRServer> signalRHub)
    {
        _context = context;
        _signalRHub = signalRHub;
    }
    public PaginatedList<Event> Events { get; set; }
    public string TitleSort { get; set; }
    public string StartTimeSort { get; set; }
    public string CategorySort { get; set; }
    public string CurrentFilter { get; set; }
    public string CurrentSort { get; set; }
    public string StartDateFilter { get; set; }
    public string EndDateFilter { get; set; }

    public IList<EventViewModel> EventViewModels { get; set; }

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
        // L?y danh sách các s? ki?n t? c? s? d? li?u
        var events = await _context.Events.ToListAsync();

        EventViewModels = new List<EventViewModel>();

        // L?p qua t?ng s? ki?n ?? tính toán s? l??ng ng??i tham d? và thêm vào danh sách ViewModel
        foreach (var ev in events)
        {
            var attendeeCount = await _context.Attendees.Where(a => a.EventId == ev.EventId).CountAsync();
            var eventViewModel = new EventViewModel { Event = ev, AttendeeCount = attendeeCount };
            EventViewModels.Add(eventViewModel);

            // G?i thông ?i?p ??n SignalR Hub ?? c?p nh?t s? l??ng ng??i tham d? cho s? ki?n này
            await _signalRHub.Clients.All.SendAsync("updateAttendeeCount", ev.EventId, attendeeCount);
        } 
    }
}
}
