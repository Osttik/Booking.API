using Booking.Infrastruture.Repositories;
using Booking.Infrastruture.Repositories.Shared;
using Booking.Infrastruture.Results;
using Booking.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Infrastruture.ValidationServices.Shared
{
    public interface IPendingValidationService
    {
        public ErrorableResult ValidateBooking(BookedSeat seat, IBookingSeatRepository bookingSeatRepository);
        public ErrorableResult ValidatePending(Guid userId, Guid pendingId, IPendingRepository repository, IUserRepository userRepository, IUserValidationService userValidationService);
    }
}
