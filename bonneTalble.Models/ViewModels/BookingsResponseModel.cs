using System.Collections.Generic;

namespace bonneTable.Models.ViewModels
{
    public class BookingResponseModel
    {
        public bool Success { get; set; }
        public string ErrorMessage { get; set; }
        public string ConfirmationNumber { get; set; }
        public List<Booking> Bookings { get; set; }
    }
}
