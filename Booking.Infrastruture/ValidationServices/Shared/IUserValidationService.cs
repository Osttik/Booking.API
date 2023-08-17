using Booking.Infrastruture.Repositories.Shared;
using Booking.Infrastruture.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Infrastruture.ValidationServices.Shared
{
    public interface IUserValidationService
    {
        public ErrorableResult ValidateUserExistance(Guid id, IUserRepository repository);
    }
}
