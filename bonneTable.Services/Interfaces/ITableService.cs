using bonneTable.Models.ViewModels;
using System;
using System.Threading.Tasks;
using bonneTable.Models;

namespace bonneTable.Services.Interfaces
{
    public interface ITableService
    {
        Task<TableResponseModel> Add(int numberOfSeats);
        Task<TableResponseModel> Delete(Guid id);
        Task<TableResponseModel> Get(Guid id);
        Task<TableResponseModel> Get();
        Task<TableResponseModel> Edit(Guid id, Table table);
    }
}
