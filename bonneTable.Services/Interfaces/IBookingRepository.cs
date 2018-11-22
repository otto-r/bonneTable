using bonneTable.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace bonneTable.Services.Interfaces
{
    public interface IBookingRepository : IRepository<Booking>
    {
        Task<Booking> GetByEmail(string email);
    }
}
