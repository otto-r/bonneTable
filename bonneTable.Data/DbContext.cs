using bonneTable.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace bonneTable.Data
{
    public class DbContext
    {
        private readonly IMongoDatabase _database = null;

        public DbContext(IOptions<Settings> settings)
        {
            var client = new MongoClient(settings.Value.ConnectionString);
            if (client != null)
            {
                _database = client.GetDatabase(settings.Value.Database);
            }
        }

        public IMongoCollection<Booking> Booking
        {
            get
            {
                return _database.GetCollection<Booking>("Booking");
            }
        }
        public IMongoCollection<Restaurant> Restaurant
        {
            get
            {
                return _database.GetCollection<Restaurant>("Restaurant");
            }
        }
        public IMongoCollection<RestaurantAdmin> RestaurantAdmin
        {
            get
            {
                return _database.GetCollection<RestaurantAdmin>("RestaurantAdmin");
            }
        }
        public IMongoCollection<Table> Table
        {
            get
            {
                return _database.GetCollection<Table>("Table");
            }
        }
    }
}
