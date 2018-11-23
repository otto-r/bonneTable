using bonneTable.Models.ViewModels;
using System;
using System.Threading.Tasks;

namespace bonneTable.Services.Interfaces
{
    public interface ITableService
    {
        Task<TableResponseModel> Add(int numberOfSeats);
        Task<TableResponseModel> Delete(Guid id);
        Task<TableResponseFeedbackModel> Get(Guid id);
        Task<TableResponseFeedbackModel> Get();
        Task<TableResponseModel> Edit(Guid id);
    }
}
