using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Models.DTO
{
    public class UpdateMovieDTO : MovieDTO
    {
        public Guid Id { get; }
    }
}
