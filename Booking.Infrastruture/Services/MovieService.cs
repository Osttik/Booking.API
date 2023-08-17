using Booking.Infrastruture.MapperService;
using Booking.Infrastruture.Repositories.Shared;
using Booking.Infrastruture.Results;
using Booking.Infrastruture.Services.Shared;
using Booking.Infrastruture.ValidationServices.Shared;
using Booking.Models.DTO;
using Booking.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Infrastruture.Services
{
    public class MovieService : IMovieService
    {
        protected readonly IMovieRepository _movieRepository;
        protected readonly IMovieValidationService _movieValidationService;

        public MovieService(IMovieRepository movieRepository, IMovieValidationService movieValidationService)
        {
            _movieRepository = movieRepository;
            _movieValidationService = movieValidationService;
        }

        public int GetCount()
        {
            return _movieRepository.GetCount();
        }

        public ListResult<MovieDTO> GetMovies(int page, int pageSize)
        {
            var countOfMovies = GetCount();
            var pageValidationResult = _movieValidationService.ValidatePage(page, pageSize, countOfMovies);

            if (!pageValidationResult.Success)
            {
                return new ListResult<MovieDTO>(pageValidationResult.Errors,
                    new List<MovieDTO>(),
                    false,
                    countOfMovies,
                    page,
                    pageSize);
            }

            var movies = _movieRepository.GetMovies(page, pageSize).Select(m => m.ToDTO());

            return new ListResult<MovieDTO>(new List<string>(),
                    movies,
                    true,
                    countOfMovies,
                    page,
                    pageSize);
        }

        public async Task<ErrorableResult> AddMovie(MovieDTO movieDTO)
        {
            await _movieRepository.AddMovie(movieDTO.ToEntity());
            return new ErrorableResult(new List<string>(), true);
        }

        public async Task<ErrorableResult> UpdateMovie(UpdateMovieDTO movieDTO)
        {
            if (!_movieRepository.HasMovie(movieDTO.Id))
            {
                return new ErrorableResult($"No movie with {movieDTO.Id} id are not present", false);
            }

            await _movieRepository.UpdateMovie(movieDTO.ToEntity());

            return ErrorableResult.OK;
        }

        public async Task<ErrorableResult> DeleteMovie(Guid id)
        {
            if (!_movieRepository.HasMovie(id))
            {
                return new ErrorableResult($"Movie with {id} id are not present", false);
            }

            await _movieRepository.Delete(id);

            return ErrorableResult.OK;
        }
    }
}
