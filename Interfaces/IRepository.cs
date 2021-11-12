using System.Collections.Generic;
using System.Threading.Tasks;

namespace MovieProject.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<TEntity> GetByIdAsync(int id);
        IEnumerable<TEntity> GetAllAsync();
        Task<bool> AddAsync(TEntity entity);
        Task<bool> AddRangeAsync(IEnumerable<TEntity> entities);

        bool Remove(TEntity entity);
        bool RemoveRange(IEnumerable<TEntity> entities);

        bool Update(TEntity entity);



    }
}
