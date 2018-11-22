﻿using System;
using System.Collections.Generic;
using System.Text;

namespace bonneTalble.Models
{
    public class Booking
    {
        public Guid Id { get; set; }
        public DateTime Time { get; set; }
        public int Seats { get; set; }
        public Table Table { get; set; }
        public string CustomerName { get; set; }
        public string PhoneNumber { get; set; }
        public string EMail { get; set; }
        public string MyProperty { get; set; }
    }
}
