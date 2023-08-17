using Booking.Models.DTO;
using Booking.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Infrastruture.MapperService
{
    public static class MappingService
    {
        public static MovieDTO ToDTO(this Movie movie)
        {
            return new MovieDTO()
            {
                Title = movie.Title,
                Description = movie.Description,
                Duration = movie.Duration,
                Genre = movie.Genre.Name
            };
        }
        public static Movie ToEntity(this MovieDTO movie)
        {
            return new Movie()
            {
                Title = movie.Title,
                Description = movie.Description,
                Duration = movie.Duration,
                Genre = new Genre() { Name = movie.Genre }
            };
        }
        public static Movie ToEntity(this UpdateMovieDTO movieDTO)
        {
            return new Movie() { Title = movieDTO.Title, Description = movieDTO.Description, Duration = movieDTO.Duration, Genre = new Genre() { Name = movieDTO.Genre } };
        }
        public static BookedSeatDTO ToDTO(this BookedSeat bookedSeat)
        {
            return new BookedSeatDTO()
            {
                ColumnNumber = bookedSeat.ColumnNumber,
                RowNumber = bookedSeat.RowNumber
            };
        }
        public static BookedSeat ToEntity(this BookedSeatDTO bookedSeatDTO)
        {
            return new BookedSeat()
            {
                ColumnNumber = bookedSeatDTO.ColumnNumber,
                RowNumber = bookedSeatDTO.RowNumber
            };
        }
    }
}
