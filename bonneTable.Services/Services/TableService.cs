using bonneTable.Models;
using bonneTable.Models.RequestModels;
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
        private readonly IRepository<Table> _repository;

        public TableService(IRepository<Table> repository)
        {
            _repository = repository;
        }

        public async Task<TableResponseModel> Add(int numberOfSeats)
        {
            if (numberOfSeats <= 0)
            {
                return new TableResponseModel() { ErrorMessage = "Seats cannot be less than or equal to 0", Success = false, Tables = null };
            }

            var table = new Table() { Seats = numberOfSeats };
            try
            {
                await _repository.AddAsync(table);
            }
            catch (Exception e)
            {
                return new TableResponseModel() { ErrorMessage = e.Message, Success = false, Tables = null };
            }
            return new TableResponseModel() { ErrorMessage = null, Success = true, Tables = null };
        }

        public async Task<TableResponseModel> Delete(Guid id)
        {
            try
            {
                await _repository.Delete(id);
            }
            catch (Exception e)
            {
                return new TableResponseModel() { ErrorMessage = e.Message, Success = false, Tables = null };
            }
            return new TableResponseModel() { ErrorMessage = null, Success = true, Tables = null };
        }

        public async Task<TableResponseModel> Edit(Guid id, TableRequestModel tableRequest)
        {
            try
            {
                await _repository.EditAsync(id, new Table {Seats = tableRequest.numberOfSeats });
            }
            catch (Exception e)
            {
                return new TableResponseModel() { ErrorMessage = e.Message, Success = false, Tables = null };
            }
            return new TableResponseModel() { ErrorMessage = null, Success = true, Tables = null };
        }

        public async Task<TableResponseModel> Get(Guid id)
        {
            Table table;
            try
            {
                table = await _repository.GetByID(id);
            }
            catch (Exception e)
            {
                return new TableResponseModel() { ErrorMessage = e.Message, Success = false, Tables = null };
            }

            if (table == null)
            {
                return new TableResponseModel() { ErrorMessage = $"Unable to find table with Id {id}", Success = false, Tables = null };
            }

            return new TableResponseModel() { ErrorMessage = null, Success = true, Tables = new List<Table>() { table } };
        }

        public async Task<TableResponseModel> Get()
        {
            List<Table> tables;
            try
            {
                tables = await _repository.GetAll();
            }
            catch (Exception e)
            {
                return new TableResponseModel() { ErrorMessage = e.Message, Success = false, Tables = null };
            }

            return new TableResponseModel() { ErrorMessage = null, Success = true, Tables = tables };
        }
    }
}
