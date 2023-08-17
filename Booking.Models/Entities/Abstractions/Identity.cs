using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Models.Entities.Abstractions
{
    public abstract class Identity
    {
        public Guid Id { get; set; }
    }
}
