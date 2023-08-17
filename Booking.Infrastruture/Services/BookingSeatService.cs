using Booking.Infrastruture.MapperService;
using Booking.Infrastruture.Repositories;
using Booking.Infrastruture.Repositories.Shared;
using Booking.Infrastruture.Results;
using Booking.Infrastruture.Services.Shared;
using Booking.Infrastruture.ValidationServices;
using Booking.Infrastruture.ValidationServices.Shared;
using Booking.Models.DTO;
using Booking.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Infrastruture.Services
{
    public class BookingSeatService : IBookingSeatService
    {
        protected readonly IBookingSeatRepository _bookingSeatRepository;
        protected readonly IPendingRepository _pendingRepository;
        protected readonly IPendingValidationService _pendingValidationService;
        protected readonly IUserRepository _userRepository;
        protected readonly IUserValidationService _userValidationService;
        public BookingSeatService(
            IBookingSeatRepository bookingSeatRepository, 
            IPendingRepository pendingRepository, 
            IPendingValidationService pendingValidationService, 
            IUserRepository userRepository, 
            IUserValidationService userValidationService)
        {
            _bookingSeatRepository = bookingSeatRepository;
            _pendingRepository = pendingRepository;
            _userRepository = userRepository;
            _pendingValidationService = pendingValidationService;
            _userValidationService = userValidationService;
        }

        public async Task<ErrorableResult> Book(Guid userId, BookedSeatDTO seatDTO)
        {
            var userValidation = _userValidationService.ValidateUserExistance(userId, _userRepository);
            if (!userValidation.Success)
            {
                return userValidation;
            }

            var seat = seatDTO.ToEntity();
            seat.Booker = _userRepository.GetById(userId);

            var validationResult = _pendingValidationService.ValidateBooking(seatDTO.ToEntity(), _bookingSeatRepository);
            if (!validationResult.Success)
            {
                return validationResult;
            }
            await _bookingSeatRepository.Add(seat);
            await _pendingRepository.CreatePending(new BookingPending()
            {
                Seat = seat,
                DateCreated = DateTime.UtcNow,
                DateToExpire = DateTime.UtcNow + TimeSpan.FromDays(1)
            });

            return ErrorableResult.OK;
        }

        public async Task<ErrorableResult> Confirm(Guid userId, Guid pendingId)
        {
            var pendingValidation = _pendingValidationService.ValidatePending(userId, pendingId, _pendingRepository, _userRepository, _userValidationService);
            if (!pendingValidation.Success)
            {
                return pendingValidation;
            }

            await _pendingRepository.Delete(pendingId);

            return ErrorableResult.OK;
        }

        public async Task<ErrorableResult> Cancel(Guid userId, Guid pendingId)
        {
            var pendingValidation = _pendingValidationService.ValidatePending(userId, pendingId, _pendingRepository, _userRepository, _userValidationService);
            if (!pendingValidation.Success)
            {
                return pendingValidation;
            }

            await _pendingRepository.Delete(pendingId);
            await _bookingSeatRepository.Delete(_pendingRepository.GetBytId(pendingId).Id);

            return ErrorableResult.OK;
        }
    }
}
