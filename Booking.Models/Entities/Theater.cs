using Booking.Models.Entities.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#nullable disable

namespace Booking.Models.Entities
{
    public class Theater : Identity
    {
        public int SeatsInRow { get; set; }
        public int SeatsInColumn { get; set; }
        public virtual ICollection<ShowTime> ShowTimes { get; set; }
    }
}
