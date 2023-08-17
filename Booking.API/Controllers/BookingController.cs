using Booking.Infrastruture.Results;
using Booking.Infrastruture.Services.Shared;
using Booking.Models.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Booking.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingSeatService _bookingSeatService;
        public BookingController(IBookingSeatService bookingSeatService)
        {
            _bookingSeatService = bookingSeatService;
        }

        [HttpPost]
        public Task<ErrorableResult> Post(Guid userId, BookedSeatDTO bookedSeatDTO)
        {
            return _bookingSeatService.Book(userId, bookedSeatDTO);
        }

        [HttpPost("/confirm")]
        public Task<ErrorableResult> Post(Guid userId, Guid pendingId)
        {
            return _bookingSeatService.Confirm(userId, pendingId);
        }
        [HttpPost("/cancel")]
        public Task<ErrorableResult> Cancel(Guid userId, Guid pendingId)
        {
            return _bookingSeatService.Cancel(userId, pendingId);
        }
    }
}
