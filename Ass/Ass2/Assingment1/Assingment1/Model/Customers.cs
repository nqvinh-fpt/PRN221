using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace HotelManagement.Model
{
    public partial class Customers
    {
        public Customers()
        {
            Bookings = new HashSet<Bookings>();
        }
        public int customer_id { get; set; }
        public string? name { get; set; }
        public string? phone_number { get; set; }
        public string? email { get; set; }
        public string? address { get; set; }

        public virtual ICollection<Bookings> Bookings { get; set; }
    }
}
