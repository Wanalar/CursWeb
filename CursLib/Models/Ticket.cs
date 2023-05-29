using System;
using System.Collections.Generic;

namespace CursLib.Models
{
    public partial class Ticket
    {
        public int TicketId { get; set; }
        public int? Trip { get; set; }
        public int? Iduser { get; set; }

        public virtual User? IduserNavigation { get; set; }
        public virtual Trip? TripNavigation { get; set; }
    }
}
