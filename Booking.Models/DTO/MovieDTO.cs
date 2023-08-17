using Booking.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#nullable disable

namespace Booking.Models.DTO
{
    public class MovieDTO
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int Duration { get; set; }
        public string Genre { get; set; }
    }
}
