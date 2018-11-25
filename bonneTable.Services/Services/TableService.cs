using bonneTable.Models.ViewModels;
using bonneTable.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace bonneTable.Services.Services
{
    public class TableService : ITableService
    {
        public Task<TableResponseModel> Add(int numberOfSeats)
        {
            throw new NotImplementedException();
        }

        public Task<TableResponseModel> Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<TableResponseModel> Edit(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<TableResponseFeedbackModel> Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<TableResponseFeedbackModel> Get()
        {
            throw new NotImplementedException();
        }
    }
}
