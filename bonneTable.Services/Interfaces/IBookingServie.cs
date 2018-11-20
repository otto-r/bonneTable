using bonneTalble.Models.RequestModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace bonneTable.Services.Interfaces
{
    public interface IBookingServie
    {
        Task ClientBookTable(BookingRequestModel booking);
        Task AdminBookTable(BookingRequestModel booking);
        Task AdminCancelBooking(int id);
        Task EditBooking(BookingRequestModel booking, int id);
    }
}
