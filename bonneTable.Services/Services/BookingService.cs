using bonneTable.Services.Interfaces;
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
        public Task AdminBookTable(BookingRequestModel bookingRequest)
        {
            throw new NotImplementedException();
        }

        public Task AdminCancelBooking(int id)
        {
            throw new NotImplementedException();
        }

        public Task<BookingViewModel> ClientBookTable(BookingRequestModel bookingRequest)
        {
            throw new NotImplementedException();
        }

        public Task EditBooking(BookingRequestModel bookingRequest, int id)
        {
            throw new NotImplementedException();
        }
    }
}
