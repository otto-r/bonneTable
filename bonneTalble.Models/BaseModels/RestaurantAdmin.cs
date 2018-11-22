using System;

namespace bonneTalble.Models
{
    public class RestaurantAdmin
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string EMail { get; set; }
        public string password { get; set; }
    }
}