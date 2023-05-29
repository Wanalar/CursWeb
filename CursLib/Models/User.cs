using System;
using System.Collections.Generic;

namespace CursLib.Models
{
    public partial class User
    {
        public User()
        {
            Tickets = new HashSet<Ticket>();
        }

        public int UserId { get; set; }
        public int? Role { get; set; }
        public string? Password { get; set; }
        public string? FirstName { get; set; }
        public string? SecondName { get; set; }
        public string? Patronymic { get; set; }
        public string? Email { get; set; }
        public long? PhonNumber { get; set; }
        public string? Login { get; set; }

        public virtual Role? RoleNavigation { get; set; }
        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}
