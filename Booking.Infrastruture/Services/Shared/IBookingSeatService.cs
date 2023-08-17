using Booking.Infrastruture.Results;
using Booking.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Infrastruture.Services.Shared
{
    public interface IBookingSeatService
    {
        public Task<ErrorableResult> Book(Guid user, BookedSeatDTO seatDTO);
        public Task<ErrorableResult> Confirm(Guid userId, Guid pendingId);
        public Task<ErrorableResult> Cancel(Guid userId, Guid pendingId);
    }
}
