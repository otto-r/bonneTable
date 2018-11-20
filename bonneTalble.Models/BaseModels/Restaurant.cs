using System;
using System.Collections.Generic;

namespace bonneTalble.Models
{
    public class Restaurant
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public RestaurantAdmin RestaurantAdmin { get; set; }
        public List<Table> Tables { get; set; }
        public string Address { get; set; }
    }
}
