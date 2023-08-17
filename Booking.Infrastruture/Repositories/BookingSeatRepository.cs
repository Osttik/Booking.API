using Booking.Infrastruture.Repositories.Shared;
using Booking.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Infrastruture.Repositories
{
    public class BookingSeatRepository : IBookingSeatRepository
    {
        protected readonly BookingDBContext _dbContext;
        public BookingSeatRepository(BookingDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public bool HasAny(Guid id)
        {
            return _dbContext.BookedSeats.Any(e => e.Id == id);
        }
        public bool HasAny(BookedSeat seat)
        {
            return _dbContext.BookedSeats.Any(e => e.RowNumber == seat.RowNumber && e.ColumnNumber == seat.ColumnNumber);
        }

        public Task Add(BookedSeat seat)
        {
            _dbContext.BookedSeats.Add(seat);
            return _dbContext.SaveChangesAsync();
        }

        public Task Delete(Guid id)
        {
            BookedSeat seat = new() { Id = id };
            _dbContext.BookedSeats.Attach(seat);
            _dbContext.BookedSeats.Remove(seat);
            return _dbContext.SaveChangesAsync();
        }
    }
}
