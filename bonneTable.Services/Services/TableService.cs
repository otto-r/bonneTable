using bonneTable.Models;
using bonneTable.Models.RequestModels;
using bonneTable.Models.ViewModels;
using bonneTable.Services.Interfaces;
using Serilog;
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

            Log.Logger = new LoggerConfiguration()
            .WriteTo.Console()
            .WriteTo.File("C:\\test\\log.txt")
            .CreateLogger();
        }

        public async Task<TableResponseModel> Add(int numberOfSeats)
        {
            if (numberOfSeats <= 0)
            {
                return TableResponseModel.Create(false, "Seats cannot be less than or equal to 0", null);
            }

            var table = new Table() { Seats = numberOfSeats };

            try
            {
                await _repository.AddAsync(table);
            }
            catch (Exception e)
            {
                Log.Information("Failed to add table with {0} seats", numberOfSeats);
                return TableResponseModel.Create(false, e.Message, null);
            }

            Log.Information("Added table with {0} seats", numberOfSeats);
            return TableResponseModel.Create(true, null, null);
        }

        public async Task<TableResponseModel> Delete(Guid id)
        {
            try
            {
                await _repository.Delete(id);
            }
            catch (Exception e)
            {
                Log.Debug("Failed to delete table {0}", id);
                return TableResponseModel.Create(false, e.Message, null);
            }

            Log.Information("Deleted table {0}", id);
            return TableResponseModel.Create(true, null, null);
        }

        public async Task<TableResponseModel> Edit(Guid id, TableRequestModel tableRequest)
        {
            try
            {
                await _repository.EditAsync(id, new Table { Seats = tableRequest.numberOfSeats });
            }
            catch (Exception e)
            {
                Log.Information("Failed to edit table {0}, info: {1}", id, tableRequest);
                return TableResponseModel.Create(false, e.Message, null);
            }

            Log.Information("Editet, info: {0}", tableRequest);
            return TableResponseModel.Create(true, null, null);
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
                Log.Debug("Tried to find a table with id {0}. Error message: {1}", id, e.Message);
                return TableResponseModel.Create(false, e.Message, null);
            }

            if (table == null)
            {
                Log.Information("Failed to find table with id {0}", id);
                return TableResponseModel.Create(false, $"Unable to find table with Id {id}", null);
            }

            Log.Information("Got table with id {0}", id);
            return TableResponseModel.Create(true, null, new List<Table>() { table });
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
                Log.Information("Failed to get all tables");
                return TableResponseModel.Create(false, e.Message, null);
            }

            Log.Information("Got all tables");
            return TableResponseModel.Create(true, null, tables);
        }
    }
}
