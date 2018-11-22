using bonneTable.Models;
using bonneTable.Models.RequestModels;
using bonneTable.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace bonneTable.Services.Interfaces
{
    public interface IBookingService
    {
        Task<BookingsResponseModel> ClientBookTable(BookingRequestModel bookingRequest);
        Task<BookingsResponseModel> AdminBookTable(BookingRequestModel bookingRequest);
        Task<List<Booking>> GetBookigsByDate(DateTime dateTime);
        Task AdminCancelBooking(Guid id);
        Task EditBooking(BookingRequestModel bookingRequest, Guid id);
        Task<List<Booking>> SearchByEmail(string email);
    }
}
