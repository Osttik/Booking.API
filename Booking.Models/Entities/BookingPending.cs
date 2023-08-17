using Booking.Models.Entities.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#nullable disable

namespace Booking.Models.Entities
{
    public class BookingPending : Identity
    {
        public BookedSeat Seat { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateToExpire { get; set; }
    }
}
