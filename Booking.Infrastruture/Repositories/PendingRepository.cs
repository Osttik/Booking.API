using Booking.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Infrastruture.Repositories
{
    public class PendingRepository
    {
        protected readonly BookingDBContext _dbContext;
        public PendingRepository(BookingDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public bool HasAny(Guid id)
        {
            return _dbContext.BookingPendings.Any(e => e.Id == id);
        }
        public BookingPending GetBytId(Guid id)
        {
            return _dbContext.BookingPendings.First(u => u.Id == id);
        }
        public Task CreatePending(BookingPending pending)
        {
            _dbContext.BookingPendings.Add(pending);
            return _dbContext.SaveChangesAsync();
        }
        public Task Delete(Guid id)
        {
            BookingPending pending = new() { Id = id };
            _dbContext.BookingPendings.Attach(pending);
            _dbContext.BookingPendings.Remove(pending);
            return _dbContext.SaveChangesAsync();
        }

        public Task DeleteExpired()
        {
            var expired = _dbContext.BookingPendings.Where(e => e.DateToExpire < DateTime.UtcNow).ToList();
            expired.ForEach(e => _dbContext.Remove(e.Seat));
            _dbContext.RemoveRange(expired);

            return _dbContext.SaveChangesAsync();
        }
    }
}
