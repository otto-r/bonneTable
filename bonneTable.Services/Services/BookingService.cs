using bonneTable.Services.Interfaces;
using bonneTable.Models;
using bonneTable.Models.RequestModels;
using bonneTable.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace bonneTable.Services.Services
{
    public class BookingService : IBookingService
    {
        private readonly IRepository _repository;

        public BookingService(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<BookingViewModel> AdminBookTable(BookingRequestModel bookingRequest)
        {
            if (bookingRequest == null)
            {
                return new BookingViewModel { Success = false, ErrorMessage = "Bad request" };
            }

            if (bookingRequest.Seats <= 0)
            {
                return new BookingViewModel { Success = false, ErrorMessage = "Bad number of seats" };
            }

            // logic to see if seats are available
            // Get bookings and tables to see how many available
            // seats and time slots there are
            var datesBookings = _repository.GetDatesBookings(bookingRequest.Time);



            Booking booking = new Booking
            {
                Seats = bookingRequest.Seats,
                PhoneNumber = bookingRequest.PhoneNumber,
                CustomerName = bookingRequest.CustomerName,
                Time = bookingRequest.Time,
                Email = bookingRequest.Email,
                //select table
            };

            await _repository.Add(booking);

            return new BookingViewModel { Success = true };
        }

        public async Task AdminCancelBooking(Guid id)
        {
            throw new NotImplementedException();
            //await _repository.Delete(id);
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

            // logic to see if seats are available
            // Get bookings and tables to see how many available
            // seats and time slots there are
            var datesBookings = _repository.GetDatesBookings(bookingRequest.Time);


            Booking booking = new Booking
            {
                Seats = bookingRequest.Seats,
                PhoneNumber = bookingRequest.PhoneNumber,
                CustomerName = bookingRequest.CustomerName,
                Time = bookingRequest.Time,
                Email = bookingRequest.Email,
                //select table
            };

            await _repository.Add(booking);

            return new BookingViewModel { Success = true };
        }

        public Task EditBooking(BookingRequestModel bookingRequest, Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
