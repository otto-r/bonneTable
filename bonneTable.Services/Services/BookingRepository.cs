using bonneTable.Data;
using bonneTable.Models;
using bonneTable.Services.Interfaces;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace bonneTable.Services.Services
{
    public class BookingRepository : IBookingRepository
    {
        private readonly DbContext _context = null;

        public BookingRepository(IOptions<Settings> settings)
        {
            _context = new DbContext(settings);
        }

        public async Task<List<Booking>> GetAll()
        {
            try
            {
                return await _context.Booking.Find(_ => true).ToListAsync();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<List<Booking>> GetByDate(DateTime dateTime)
        {
            var dateTimeStripped = dateTime.AddMinutes(-dateTime.Minute);
            dateTimeStripped = dateTime.AddHours(-dateTime.Hour);

            var time2359 = dateTimeStripped.AddHours(23);
            var time0001 = dateTimeStripped.AddMinutes(1);

            try
            {
                return await _context.Booking.Find(b => b.Time > time0001 && b.Time < time2359).ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<Booking>> GetByEmail(string email)
        {
            try
            {
                return await _context.Booking.Find(b => b.Email.ToLower().Contains(email.ToLower())).ToListAsync();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<Booking> GetByID(Guid ID)
        {
            try
            {
                return await _context.Booking.Find(b => b.Id == ID).SingleOrDefaultAsync();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task AddAsync(Booking entity)
        {
            try
            {
                await _context.Booking.InsertOneAsync(entity);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task Delete(Guid ID)
        {
            try
            {
                await _context.Booking.DeleteOneAsync(b => b.Id == ID);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<bool> EditAsync(Guid ID, Booking entity)
        {
            try
            {


                var filter = Builders<Booking>.Filter.Eq(t => t.Id, ID);
                ReplaceOneResult replaceOneResult = await _context.Booking.ReplaceOneAsync(filter, entity,
                    new UpdateOptions { IsUpsert = true });

                return replaceOneResult.IsAcknowledged && replaceOneResult.MatchedCount > 0;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public Task Commit()
        {
            throw new NotImplementedException();
        }

    }
}
