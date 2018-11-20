using System.Threading.Tasks;

namespace bonneTable.Services.Interfaces
{
    public interface IRepository
    {
        Task Add<TEntity>(TEntity entity) where TEntity : class;
        Task Delete<TEntity>(TEntity entity) where TEntity : class;
        Task Edit<TEntity>(TEntity entity) where TEntity : class;
        Task Commit();
    }
}
