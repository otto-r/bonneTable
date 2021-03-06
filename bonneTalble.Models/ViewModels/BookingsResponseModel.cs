﻿using System.Collections.Generic;

namespace bonneTable.Models.ViewModels
{
    public class BookingResponseModel
    {
        public bool Success { get; set; }
        public string ErrorMessage { get; set; }
        public string ConfirmationNumber { get; set; }
        public List<Booking> Bookings { get; set; }

        public static BookingResponseModel Create(bool success = false, string errormsg = null, string confirmationNr = null, List<Booking> bookings = null)
        {
            return new BookingResponseModel() { Success = success, ErrorMessage = errormsg, ConfirmationNumber = confirmationNr, Bookings = bookings };
        }
    }
}
