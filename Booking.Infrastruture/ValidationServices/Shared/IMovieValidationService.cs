using Booking.Infrastruture.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Infrastruture.ValidationServices.Shared
{
    public interface IMovieValidationService
    {
        public ErrorableResult ValidatePage(int page, int pageSize, int count);
    }
}
