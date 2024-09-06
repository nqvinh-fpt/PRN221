using System;
using System.Collections.Generic;

namespace _04_NQVinh_Assignment01.Models
{
    public partial class Member
    {
        public int MemberId { get; set; }
        public int? UserId { get; set; }
        public string? Name { get; set; }
        public DateTime? Dob { get; set; }
        public string? City { get; set; }
        public string? Country { get; set; }

        public virtual User? User { get; set; }
    }
}
