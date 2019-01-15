using MongoDB.Bson.Serialization.Attributes;
using System;

namespace bonneTable.Models
{
    public class Booking
    {
        [BsonId]
        [BsonRequired]
        public Guid Id { get; set; }
        [BsonRequired]
        public DateTime Time { get; set; }
        [BsonRequired]
        [BsonDefaultValue(1)]
        public int Seats { get; set; }
        [BsonRequired]
        public Table Table { get; set; }
        [BsonRequired]
        public string CustomerName { get; set; }
        [BsonRequired]
        public string PhoneNumber { get; set; }
        [BsonRequired]
        public string Email { get; set; }
    }
}
