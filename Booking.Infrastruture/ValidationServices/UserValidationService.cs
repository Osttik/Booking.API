using Booking.Infrastruture.Repositories.Shared;
using Booking.Infrastruture.Results;
using Booking.Infrastruture.ValidationServices.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Infrastruture.ValidationServices
{
    public class UserValidationService : IUserValidationService
    {
        public ErrorableResult ValidateUserExistance(Guid id, IUserRepository repository)
        {
            if (!repository.HasAny(id))
            {
                return new ErrorableResult("Incorrect user", false);
            }

            return ErrorableResult.OK;
        }
    }
}
