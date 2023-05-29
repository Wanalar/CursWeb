using System;
using System.Collections.Generic;

namespace CursLib.Models
{
    public partial class Trip
    {
        public Trip()
        {
            Tickets = new HashSet<Ticket>();
        }

        public int TripId { get; set; }
        public string? DepartureTime { get; set; }
        public string? ArivalTime { get; set; }
        public string? BusStop { get; set; }
        public int? Bus { get; set; }
        public decimal? Cost { get; set; }

        public virtual Bus? BusNavigation { get; set; }
        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}
