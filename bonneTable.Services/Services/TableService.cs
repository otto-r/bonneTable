using bonneTable.Models;
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
        }

        public async Task<TableResponseModel> Add(int numberOfSeats)
        {
            Log.Logger = new LoggerConfiguration()
            .WriteTo.Console()
            .WriteTo.File("C:\\test\\log.txt")
            .CreateLogger();
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
                Log.Information("Failed to add table with {Seats} seats", numberOfSeats);
                return new TableResponseModel() { ErrorMessage = e.Message, Success = false, Tables = null };
            }
            Log.Information("Added table with {Seats} seats", numberOfSeats);
            return new TableResponseModel() { ErrorMessage = null, Success = true, Tables = null };
        }

        public async Task<TableResponseModel> Delete(Guid id)
        {
            Log.Logger = new LoggerConfiguration()
            .WriteTo.Console()
            .WriteTo.File("C:\\test\\log.txt")
            .CreateLogger();

            try
            {
                await _repository.Delete(id);
            }
            catch (Exception e)
            {
                Log.Debug("Failed to delete table {Id}", id);
                return new TableResponseModel() { ErrorMessage = e.Message, Success = false, Tables = null };
            }
            Log.Information("Deleted table {Id}", id);
            return new TableResponseModel() { ErrorMessage = null, Success = true, Tables = null };
        }

        public async Task<TableResponseModel> Edit(Guid id, Table table)
        {
            Log.Logger = new LoggerConfiguration()
            .WriteTo.Console()
            .WriteTo.File("C:\\test\\log.txt")
            .CreateLogger();

            try
            {
                await _repository.EditAsync(id, table);
            }
            catch (Exception e)
            {
                Log.Information("Failed to edit table {Id}, info: {Table}", id, table);
                return new TableResponseModel() { ErrorMessage = e.Message, Success = false, Tables = null };
            }
            Log.Information("Editet, info: {Table}", table);
            return new TableResponseModel() { ErrorMessage = null, Success = true, Tables = null };
        }

        public async Task<TableResponseModel> Get(Guid id)
        {
            Log.Logger = new LoggerConfiguration()
            .WriteTo.Console()
            .WriteTo.File("C:\\test\\log.txt")
            .CreateLogger();

            Table table;
            try
            {
                table = await _repository.GetByID(id);
            }
            catch (Exception e)
            {
                Log.Debug("Tried to find a table with id {Id}. Error message: {Error}", id, e.Message);
                return new TableResponseModel() { ErrorMessage = e.Message, Success = false, Tables = null };
            }

            if (table == null)
            {
                Log.Information("Failed to find table with id {Id}", id);
                return new TableResponseModel() { ErrorMessage = $"Unable to find table with Id {id}", Success = false, Tables = null };
            }
            Log.Information("Got table with id {Id}", id);
            return new TableResponseModel() { ErrorMessage = null, Success = true, Tables = new List<Table>() { table } };
        }

        public async Task<TableResponseModel> Get()
        {
            Log.Logger = new LoggerConfiguration()
            .WriteTo.Console()
            .WriteTo.File("C:\\test\\log.txt")
            .CreateLogger();

            List<Table> tables;
            try
            {
                tables = await _repository.GetAll();
            }
            catch (Exception e)
            {
                Log.Information("Failed to get all tables");
                return new TableResponseModel() { ErrorMessage = e.Message, Success = false, Tables = null };
            }
            Log.Information("Got all tables");
            return new TableResponseModel() { ErrorMessage = null, Success = true, Tables = tables };
        }
    }
}
