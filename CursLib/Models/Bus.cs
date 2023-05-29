using System;
using System.Collections.Generic;

namespace CursLib.Models
{
    public partial class Bus
    {
        public Bus()
        {
            Trips = new HashSet<Trip>();
        }

        public int BusId { get; set; }
        public string? Number { get; set; }
        public int Site { get; set; }

        public virtual ICollection<Trip> Trips { get; set; }
    }
}
