using Booking.Models.Entities.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#nullable disable

namespace Booking.Models.Entities
{
    public class Movie : Identity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int Duration { get; set; }
        public Genre Genre { get; set; }
        public virtual ICollection<ShowTime> ShowTimes { get; set; }
    }
}
