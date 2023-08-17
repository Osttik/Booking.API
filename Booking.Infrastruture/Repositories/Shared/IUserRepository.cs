using Booking.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Infrastruture.Repositories.Shared
{
    public interface IUserRepository
    {
        public User GetById(Guid id);
        public bool HasAny(Guid id);
    }
}
