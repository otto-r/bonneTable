using bonneTable.Services.Interfaces;
using bonneTalble.Models;
using bonneTalble.Models.RequestModels;
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

        public async Task ClientBookTableAsync(BookingRequestModel bookingRequest)
        {
            Booking booking = new Booking
            { 
                Seats = bookingRequest.Seats,
                PhoneNumber = bookingRequest.PhoneNumber,
                CustomerName = bookingRequest.CustomerName,
                Time = bookingRequest.Time,
            };

            await _repository.Add(booking);
        }

        public Task EditBooking(BookingRequestModel bookingRequest, int id)
        {
            throw new NotImplementedException();
        }
    }
}
