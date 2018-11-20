using bonneTable.Services.Interfaces;
using bonneTalble.Models;
using bonneTalble.Models.RequestModels;
using bonneTalble.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace bonneTable.Services.Services
{
    public class BookingService : IBookingServie
    {
        private readonly IRepository _repository;

        public BookingService(IRepository repository)
        {
            _repository = repository;
        }

        public Task AdminBookTable(BookingRequestModel bookingRequest)
        {
            throw new NotImplementedException();
        }

        public Task AdminCancelBooking(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<BookingViewModel> ClientBookTable(BookingRequestModel bookingRequest)
        {
            if (bookingRequest == null)
            {
                return new BookingViewModel { Success = false, ErrorMessage = "Bad request" };
            }

            if (bookingRequest.Seats <= 0 || bookingRequest.Seats > 6)
            {
                return new BookingViewModel { Success = false, ErrorMessage = "Bad number of seats" };
            }

            var nameGreaterThan1 = bookingRequest.CustomerName.Length <= 1 ? true : false;
            var nameNotLongerThan50 = bookingRequest.CustomerName.Length > 50 ? true : false;
            var phoneNotShorterThan6 = bookingRequest.PhoneNumber.Length < 6 ? true : false;
            var phoneNotLongerThan25 = bookingRequest.PhoneNumber.Length > 25 ? true : false;

            if (nameGreaterThan1 || nameNotLongerThan50 || phoneNotShorterThan6 || phoneNotLongerThan25)
            {
                return new BookingViewModel { Success = false, ErrorMessage = "Invalid name or phone number" };
            }

            var now = DateTime.Now;

            if (bookingRequest.Time < now)
            {
                return new BookingViewModel { Success = false, ErrorMessage = "Can't make a booking in the past" };
            }

            Booking booking = new Booking
            {
                Seats = bookingRequest.Seats,
                PhoneNumber = bookingRequest.PhoneNumber,
                CustomerName = bookingRequest.CustomerName,
                Time = bookingRequest.Time,
            };

            await _repository.Add(booking);

            return new BookingViewModel { Success = true };
        }

        public Task EditBooking(BookingRequestModel bookingRequest, int id)
        {
            throw new NotImplementedException();
        }
    }
}
