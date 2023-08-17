using Booking.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Infrastruture.Repositories.Shared
{
    public interface IMovieRepository
    {
        public int GetCount();
        public bool HasMovie(Guid movieId);
        public IEnumerable<Movie> GetMovies(int page, int pageSize);
        public Task AddMovie(Movie movie);
        public Task UpdateMovie(Movie movie);
        public Task Delete(Guid id);
    }
}
