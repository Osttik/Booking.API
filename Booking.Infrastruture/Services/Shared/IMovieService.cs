using Booking.Infrastruture.Results;
using Booking.Models.DTO;
using Booking.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Infrastruture.Services.Shared
{
    public interface IMovieService
    {
        public int GetCount();
        public ListResult<MovieDTO> GetMovies(int page, int pageSize);
        public Task<ErrorableResult> AddMovie(MovieDTO movieDTO);
        public Task<ErrorableResult> UpdateMovie(UpdateMovieDTO movieDTO);
        public Task<ErrorableResult> DeleteMovie(Guid id);
    }
}
