using Booking.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Infrastruture.Repositories.Shared
{
    public interface IPendingRepository
    {
        public bool HasAny(Guid id);
        public Task CreatePending(BookingPending pending);
        public Task Delete(Guid id);
        public BookingPending GetBytId(Guid id);
        public Task DeleteExpired();
    }
}
