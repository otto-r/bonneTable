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
        Task<BookingResponseModel> ClientBookTable(BookingRequestModel bookingRequest);
        Task<BookingResponseModel> AdminBookTable(BookingRequestModel bookingRequest);
        Task<BookingResponseModel> EditBooking(BookingRequestModel bookingRequest, Guid id);
        Task<BookingResponseModel> Get(DateTime dateTime);
        Task<Booking> Get(Guid id);
        Task<List<Booking>> SearchByEmail(string email);
        Task<BookingResponseModel> AdminCancelBooking(Guid id);
    }
}
