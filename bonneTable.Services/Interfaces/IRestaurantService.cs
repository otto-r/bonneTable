using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace bonneTable.Services.Interfaces
{
    public interface IRestaurantService
    {
        Task AddTable(TableRequestModel requestModel);
        Task RemoveTalbe(TableRequestModel requestModel);
        Task EditTable(TableRequestModel requestModel);
    }
}
