using bonneTable.Data;
using bonneTable.Models;
using bonneTable.Services.Interfaces;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace bonneTable.Services.Services
{
    public class TableRepository : IRepository<Table>
    {
        private readonly DbContext _context = null;

        public TableRepository(IOptions<Settings> settings)
        {
            _context = new DbContext(settings);
        }

        public async Task<List<Table>> GetAll()
        {
            try
            {
                return await _context.Table.Find(_ => true).ToListAsync();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<Table> GetByID(Guid ID)
        {
            try
            {
                return await _context.Table.Find(t => t.Id == ID).SingleOrDefaultAsync();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task AddAsync(Table table)
        {
            try
            {
                await _context.Table.InsertOneAsync(table);
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
                await _context.Table.DeleteOneAsync(t => t.Id == ID);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<bool> EditAsync(Guid ID, Table table)
        {
            try
            {
                var filter = Builders<Table>.Filter.Eq(t => t.Id, ID);
                var update = Builders<Table>.Update.Set(x => x.Seats, table.Seats);

                var updateResult = await _context.Table.UpdateOneAsync(filter, update, new UpdateOptions { IsUpsert = true });

                return updateResult.IsAcknowledged && updateResult.MatchedCount > 0;
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
