using Booking.Models.Entities.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#nullable disable

namespace Booking.Models.Entities
{
    public class BookedSeat : Identity
    {
        public int RowNumber { get; set; }
        public int ColumnNumber { get; set; }
        public User Booker { get; set; }
        public ShowTime ShowTime { get; set; }
    }
}
