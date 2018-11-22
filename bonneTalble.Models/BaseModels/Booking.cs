using System;

namespace bonneTable.Models
{
    public class Booking
    {
        public Guid Id { get; set; }
        public DateTime Time { get; set; }
        public int Seats { get; set; }
        public Table Table { get; set; }
        public string CustomerName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
    }
}
