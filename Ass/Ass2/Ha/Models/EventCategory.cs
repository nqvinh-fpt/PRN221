using System;
using System.Collections.Generic;

namespace Ha.Models
{
    public partial class EventCategory
    {
        public EventCategory()
        {
            Events = new HashSet<Event>();
        }

        public int CategoryId { get; set; }
        public string CategoryName { get; set; } = null!;

        public virtual ICollection<Event> Events { get; set; }
    }
}
