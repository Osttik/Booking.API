using Booking.Infrastruture.Repositories.Shared;
using Booking.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Infrastruture.Repositories
{
    public class MovieRepository : IMovieRepository
    {
        protected readonly BookingDBContext _dbContext;

        public MovieRepository(BookingDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public int GetCount()
        {
            return _dbContext.Movies.Count();
        }

        public bool HasMovie(Guid movieId)
        {
            return _dbContext.Movies.Any(movie => movie.Id == movieId);
        }

        public IEnumerable<Movie> GetMovies(int page, int pageSize)
        {
            return _dbContext.Movies.Skip(page * pageSize).Take(pageSize).AsEnumerable();
        }

        public Task AddMovie(Movie movie)
        {
            _dbContext.Movies.Add(movie);
            return _dbContext.SaveChangesAsync();
        }

        public Task UpdateMovie(Movie movie)
        {
            _dbContext.Attach(movie);
            return _dbContext.SaveChangesAsync();
        }

        public Task Delete(Guid id)
        {
            Movie movie = new() { Id = id };
            _dbContext.Movies.Attach(movie);
            _dbContext.Movies.Remove(movie);
            return _dbContext.SaveChangesAsync();
        }
    }
}
