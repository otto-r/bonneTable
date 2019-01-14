﻿using System;

namespace bonneTable.Models.RequestModels
{
    public class BookingRequestModel
    {
        public DateTime Time { get; set; }
        public int Seats { get; set; }
        public string CustomerName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
    }
}
