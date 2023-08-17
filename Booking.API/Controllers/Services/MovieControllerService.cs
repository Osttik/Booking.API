using Booking.API.Controllers.Services.Shared;
using Booking.Infrastruture.Results;
using Booking.Models.DTO;

namespace Booking.API.Controllers.Services
{
    public class MovieControllerService : IMovieControllerService
    {
        public ErrorableResult ValidatePageArgs(int page, int pageSize)
        {
            var errors = new List<string>();

            if (page < 1) {
                errors.Add("Unreacheble page");
            }
            if (pageSize < 1)
            {
                errors.Add("Bad page size");
            }

            return new ErrorableResult(errors, errors.Count == 0);
        }

        public ErrorableResult ValidateMovie(MovieDTO movieDTO)
        {
            var errors = new List<string>();

            if (movieDTO.Genre == null || movieDTO.Genre == string.Empty)
            {
                errors.Add("Genre are required");
            }
            if (movieDTO.Duration < 1)
            {
                errors.Add("Duration are invalid");
            }
            if (movieDTO.Description == null || movieDTO.Description == string.Empty)
            {
                errors.Add("Description are required");
            }
            if (movieDTO.Title == null || movieDTO.Title == string.Empty)
            {
                errors.Add("Title are required");
            }


            return new ErrorableResult(errors, errors.Count == 0);
        }
        public ErrorableResult ValidateMovie(UpdateMovieDTO movieDTO)
        {
            var errors = new List<string>();

            if (movieDTO.Genre == null || movieDTO.Genre == string.Empty)
            {
                errors.Add("Genre are required");
            }
            if (movieDTO.Duration < 1)
            {
                errors.Add("Duration are invalid");
            }
            if (movieDTO.Description == null || movieDTO.Description == string.Empty)
            {
                errors.Add("Description are required");
            }
            if (movieDTO.Title == null || movieDTO.Title == string.Empty)
            {
                errors.Add("Title are required");
            }


            return new ErrorableResult(errors, errors.Count == 0);
        }
    }
}
