using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace AuditManagement.DataAcces.Repository.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<T?> GetAsync(Expression<Func<T, bool>> filter);
        T? Get(Expression<Func<T, bool>> filter);
        Task<IEnumerable<T>> GetListAsync(Expression<Func<T, bool>> filter);
        Task AddAsync(T entity);
        Task<int> ExecuteBulkDeleteAsync(Expression<Func<T, bool>> filter);
        Task<IEnumerable<T>?> ExecuteBulkInsertAsync(IEnumerable<T> records);
        Task<int> ExecuteBulkUpdateAsync(Expression<Func<T, bool>> filter, Expression<Func<SetPropertyCalls<T>, SetPropertyCalls<T>>> propertyUpdate);
        void Update(T entity);
    }
}
