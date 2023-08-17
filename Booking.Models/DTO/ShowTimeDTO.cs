using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Models.DTO
{
    public class ShowTimeDTO
    {
        public Guid Id { get; set; }
        /// <summary>
        /// A day of movie showtime
        /// </summary>
        public DateOnly Date { get; set; }
        /// <summary>
        /// Time of movie showtime
        /// </summary>
        public TimeOnly Time { get; set; }
    }
}
