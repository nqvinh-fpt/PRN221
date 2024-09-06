using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagement.Model
{
    public partial class Rooms
    {
        public Rooms()
        {
            Bookings = new HashSet<Bookings>();
        }

        public int room_id { get; set; }
        public string? room_type { get; set; }
        public string? status { get; set; }
        public float? price { get; set; }

        public virtual ICollection<Bookings> Bookings { get; set; }

        
    }
}
