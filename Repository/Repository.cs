using MovieProject.Data;
using MovieProject.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieProject.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly AppDbContext context;
        public Repository(AppDbContext context)
        {
            this.context = context;
        }
        public async Task<bool> AddAsync(TEntity entity)
        {
            try
            {
                await context.Set<TEntity>().AddAsync(entity);
                return true;
            }
            catch
            {
                return false;
            }

        }

        public async Task<bool> AddRangeAsync(IEnumerable<TEntity> entities)
        {

            try
            {
                await context.Set<TEntity>().AddRangeAsync(entities);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public IEnumerable<TEntity> GetAllAsync()
        {
            return context.Set<TEntity>().ToList();
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            return await context.Set<TEntity>().FindAsync(id);
        }

        public bool Remove(TEntity entity)
        {
            try
            {
                context.Set<TEntity>().Remove(entity);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool RemoveRange(IEnumerable<TEntity> entities)
        {
            try
            {
                context.Set<TEntity>().RemoveRange(entities);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Update(TEntity entity)
        {
            try
            {
                context.Set<TEntity>().Update(entity);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
