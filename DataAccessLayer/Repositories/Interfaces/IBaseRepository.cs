using DataAccessLayer.Entities;
using System.Diagnostics.Metrics;
using System.Linq.Expressions;

namespace DataAccessLayer.Repositories.Interfaces
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        Task<T> GetByIdAsync(long id);
        Task<IEnumerable<T>> GetAllAsync();
        Task<bool> IsExistAsync(long id);
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        Task<IEnumerable<T>> GetManyWithFilterAsync(Expression<Func<T, bool>> expression);
        Task<T> GetOneWithFilterAsync(Expression<Func<T, bool>> expression);
    }
}
