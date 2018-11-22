using bonneTable.Services.Interfaces;
using bonneTalble.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace bonneTable.Services.Services
{
    public class BookingRepository : IBookingRepository
    {
        public Task AddAsync(Booking entity)
        {
            throw new NotImplementedException();
        }

        public Task Commit()
        {
            throw new NotImplementedException();
        }

        public Task Delete(Guid ID)
        {
            throw new NotImplementedException();
        }

        public Task<bool> EditAsync(Guid ID, Booking entity)
        {
            throw new NotImplementedException();
        }

        public Task<List<Booking>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Booking> GetByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public Task<Booking> GetByID(Guid ID)
        {
            throw new NotImplementedException();
        }
    }
}
