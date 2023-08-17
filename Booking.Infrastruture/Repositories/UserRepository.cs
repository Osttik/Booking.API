using Booking.Infrastruture.Repositories.Shared;
using Booking.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Infrastruture.Repositories
{
    public class UserRepository : IUserRepository
    {
        protected readonly BookingDBContext _dbContext;
        public UserRepository(BookingDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public bool HasAny(Guid id)
        {
            return _dbContext.Users.Any(u => u.Id == id);
        }
        public User GetById(Guid id)
        {
            return _dbContext.Users.First(u => u.Id == id);
        }
    }
}
