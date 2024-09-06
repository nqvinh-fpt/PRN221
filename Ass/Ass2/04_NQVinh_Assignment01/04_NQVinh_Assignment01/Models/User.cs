using System;
using System.Collections.Generic;

namespace _04_NQVinh_Assignment01.Models
{
    public partial class User
    {
        public User()
        {
            Members = new HashSet<Member>();
        }

        public int UserId { get; set; }
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public bool? Role { get; set; }
        public string? Phone { get; set; }

        public virtual ICollection<Member> Members { get; set; }
    }
}
