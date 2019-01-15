using System;

namespace bonneTable.Models.ViewModels
{
    public class BookingViewModel
    {
        public Guid Id { get; set; }
        public DateTime Time { get; set; }
        public int Seats { get; set; }
        public Table Table { get; set; }
    }
}
