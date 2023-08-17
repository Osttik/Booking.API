using Booking.Infrastruture.Results;
using Booking.Infrastruture.ValidationServices.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Infrastruture.ValidationServices
{
    public class MovieValidationService : IMovieValidationService
    {
        /// <summary>
        /// Return error text if present
        /// </summary>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public ErrorableResult ValidatePage(int page, int pageSize, int count)
        {
            if (page * pageSize > count) return new ErrorableResult("Unreacheble page", false);
            return ErrorableResult.OK;
        }
    }
}
