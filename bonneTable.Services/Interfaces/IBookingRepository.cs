using bonneTalble.Models;
using System.Threading.Tasks;

namespace bonneTable.Services.Interfaces
{
    public interface IBookingRepository : IRepository<Booking>
    {
        Task<Booking> GetByEmail(string email);
    }
}
