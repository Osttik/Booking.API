using Booking.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Infrastruture.Repositories.Shared
{
    public interface IBookingSeatRepository
    {
        public bool HasAny(Guid id);
        public bool HasAny(BookedSeat seat);
        public Task Add(BookedSeat seat);
        public Task Delete(Guid id);
    }
}
