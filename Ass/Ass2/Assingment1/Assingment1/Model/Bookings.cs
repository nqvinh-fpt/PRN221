using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagement.Model
{
    public partial class Bookings
    {
        
        public int booking_id { get; set; }
        public int? customer_id { get; set; }
        public int? room_id { get; set; }
        public DateTime? checkin_date { get; set; }
        public DateTime? checkout_date { get; set; }
        public float? total_price { get; set; }

        public virtual Customers? CustomerNavigation { get; set; }
        public virtual Rooms? RoomIdNavigation { get; set; }
    }
}
