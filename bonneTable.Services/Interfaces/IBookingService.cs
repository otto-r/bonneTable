using bonneTable.Models.RequestModels;
using bonneTable.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace bonneTable.Services.Interfaces
{
    public interface IBookingService
    {
        Task<BookingViewModel> ClientBookTable(BookingRequestModel bookingRequest);
        Task AdminBookTable(BookingRequestModel bookingRequest);
        Task AdminCancelBooking(int id);
        Task EditBooking(BookingRequestModel bookingRequest, int id);
    }
}
