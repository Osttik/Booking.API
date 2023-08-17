using Booking.API.Controllers.Services.Shared;
using Booking.Infrastruture.Results;
using Booking.Infrastruture.Services.Shared;
using Booking.Models.DTO;
using Booking.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Booking.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TheatreController : ControllerBase
    {
        private readonly IMovieService _movieService;
        private readonly IMovieControllerService _service;
        public TheatreController(IMovieService movieService, IMovieControllerService service)
        {
            _movieService = movieService;
            _service = service;
        }

        [HttpGet]
        public ListResult<MovieDTO> Get(int page, int pageSize) 
        {
            var pageValidationResult = _service.ValidatePageArgs(page, pageSize);

            if (!pageValidationResult.Success)
            {
                return new ListResult<MovieDTO>(
                    pageValidationResult.Errors,
                    new List<MovieDTO>(),
                    false,
                    _movieService.GetCount(),
                    page,
                    pageSize);
            }

            return _movieService.GetMovies(page, pageSize);
        }

        [HttpPost]
        public Task<ErrorableResult> Post(MovieDTO movieDTO)
        {
            var pageValidationResult = _service.ValidateMovie(movieDTO);

            if (!pageValidationResult.Success)
            {
                return new Task<ErrorableResult>(() => pageValidationResult);
            }

            return _movieService.AddMovie(movieDTO);
        }

        [HttpPatch]
        public Task<ErrorableResult> Patch(UpdateMovieDTO movieDTO)
        {
            var pageValidationResult = _service.ValidateMovie(movieDTO);

            if (!pageValidationResult.Success)
            {
                return new Task<ErrorableResult>(() => pageValidationResult);
            }

            return _movieService.UpdateMovie(movieDTO);
        }

        [HttpDelete]
        public Task<ErrorableResult> Delete(Guid movieId)
        {
            return _movieService.DeleteMovie(movieId);
        }
    }
}
