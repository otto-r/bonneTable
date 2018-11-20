using bonneTalble.Models.RequestModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace bonneTable.Services.Interfaces
{
    public interface IBookingServie
    {
        Task<BookingViewModel> ClientBookTable(BookingRequestModel bookingRequest);
        Task AdminBookTable(BookingRequestModel bookingRequest);
        Task AdminCancelBooking(int id);
        Task EditBooking(BookingRequestModel bookingRequest, int id);
    }
}
