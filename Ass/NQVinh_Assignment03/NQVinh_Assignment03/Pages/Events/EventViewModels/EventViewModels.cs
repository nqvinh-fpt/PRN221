namespace NQVinh_Assignment03.Pages.Events.EventViewModels
{
    public class EventViewModels
    {
        public int EventId { get; set; }
        public string Title { get; set; } = null!;
        public string? Description { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public string? Location { get; set; }
        public int? CategoryId { get; set; }
    }
}
