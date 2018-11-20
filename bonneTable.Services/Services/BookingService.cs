using bonneTable.Services.Interfaces;
using bonneTalble.Models.RequestModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace bonneTable.Services.Services
{
    public class BookingService : IBookingServie
    {
        public Task AdminBookTable(BookingRequestModel booking)
        {
            throw new NotImplementedException();
        }

        public Task AdminCancelBooking(int id)
        {
            throw new NotImplementedException();
        }

        public Task ClientBookTable(BookingRequestModel booking)
        {
            throw new NotImplementedException();
        }

        public Task EditBooking(BookingRequestModel booking, int id)
        {
            throw new NotImplementedException();
        }
    }
}
