using Booking.Models.Entities.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#nullable disable

namespace Booking.Models.Entities
{
    public class ShowTime : Identity
    {
        /// <summary>
        /// A day of movie showtime
        /// </summary>
        public DateOnly Date { get ; set; }
        /// <summary>
        /// Time of movie showtime
        /// </summary>
        public TimeOnly Time { get ; set; }
        /// <summary>
        /// All booked seats
        /// </summary>
        public virtual ICollection<BookedSeat> BookedSeats { get; set; }
        public Movie Movie { get; set; }
        public Theater Theater { get; set; }
    }
}
