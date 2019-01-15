using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace bonneTable.Services.Interfaces
{
    public interface IRepository<T>
    {
        Task<List<T>> GetAll();
        Task<T> GetByID(Guid ID);
        Task AddAsync(T entity);
        Task<bool> EditAsync(Guid ID, T entity);
        Task Delete(Guid ID);
        Task Commit();
    }
}
