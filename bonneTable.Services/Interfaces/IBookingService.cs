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
        Task<BookingViewModel> AdminBookTable(BookingRequestModel bookingRequest);
        Task AdminCancelBooking(Guid id);
        Task EditBooking(BookingRequestModel bookingRequest, Guid id);
    }
}
