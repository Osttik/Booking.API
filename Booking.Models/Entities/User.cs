using Booking.Models.Entities.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#nullable disable

namespace Booking.Models.Entities
{
    /// <summary>
    /// Simple user for emulation auth
    /// </summary>
    public class User : Identity
    {
        public virtual ICollection<BookedSeat> BookedSeats { get; set; }
    }
}
