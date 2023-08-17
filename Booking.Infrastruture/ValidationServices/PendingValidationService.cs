using Booking.Infrastruture.Repositories;
using Booking.Infrastruture.Repositories.Shared;
using Booking.Infrastruture.Results;
using Booking.Infrastruture.ValidationServices.Shared;
using Booking.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Infrastruture.ValidationServices
{
    public class PendingValidationService : IPendingValidationService
    {
        public ErrorableResult ValidateBooking(BookedSeat seat, IBookingSeatRepository bookingSeatRepository)
        {
            if (bookingSeatRepository.HasAny(seat))
            {
                return new ErrorableResult("Allready booked seat", false);
            }

            return ErrorableResult.OK;
        }

        public ErrorableResult ValidatePending(Guid userId, Guid pendingId, IPendingRepository repository, IUserRepository userRepository, IUserValidationService userValidationService)
        {
            if (repository.HasAny(pendingId))
            {
                return new ErrorableResult("There are not such pending", false);
            }
            var validation = userValidationService.ValidateUserExistance(userId, userRepository);
            if (!validation.Success)
            {
                return validation;
            }
            if (repository.GetBytId(pendingId).Seat.Booker.Id != userId)
            {
                return new ErrorableResult("Current user cant manage this pending", false);
            }

            return ErrorableResult.OK;
        }
    }
}
