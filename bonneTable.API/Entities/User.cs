using bonneTable.Models;

namespace bonneTable.API.Entities
{
    public class User : RestaurantAdmin
    {
        public string Token { get; set; }
    }
}
