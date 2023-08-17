using Booking.Infrastruture.Results;
using Booking.Models.DTO;

namespace Booking.API.Controllers.Services.Shared
{
    public interface IMovieControllerService
    {
        public ErrorableResult ValidatePageArgs(int page, int pageSize);
        public ErrorableResult ValidateMovie(MovieDTO movieDTO);
    }
}
