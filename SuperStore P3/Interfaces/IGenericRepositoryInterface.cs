using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Repositories
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<IEnumerable<TEntity>> GetByConditionAsync(Expression<Func<TEntity, bool>> condition);
        Task<TEntity> GetByIdAsync(object id);
        Task CreateAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task DeleteAsync(object id);
        bool Exists(Expression<Func<TEntity, bool>> condition);
    }
}
