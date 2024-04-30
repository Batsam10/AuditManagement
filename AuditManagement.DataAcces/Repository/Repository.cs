using AuditManagement.DataAcces.Data;
using AuditManagement.DataAcces.Repository.Interfaces;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace AuditManagement.DataAcces.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDbContext db;
        internal DbSet<T> dbSet;
        public Repository(ApplicationDbContext db)
        {
            this.db = db;
            this.dbSet = db.Set<T>();
        }
        public async Task AddAsync(T entity)
        {
            await dbSet.AddAsync(entity);
        }

        public async Task<T?> GetAsync(Expression<Func<T, bool>> filter)
        {
            return await dbSet.FirstOrDefaultAsync(filter);
        }

        public T? Get(Expression<Func<T, bool>> filter)
        {
            return dbSet.FirstOrDefault(filter);
        }

        public async Task<IEnumerable<T>> GetListAsync(Expression<Func<T, bool>> filter)
        {
            return await dbSet.Where(filter).ToListAsync();
        }

        public async Task<int> ExecuteBulkUpdateAsync(Expression<Func<T, bool>> filter, Expression<Func<SetPropertyCalls<T>, SetPropertyCalls<T>>> propertyUpdate)
        {
            return await dbSet.Where(filter).ExecuteUpdateAsync(propertyUpdate);
        }

        public async Task<IEnumerable<T>?> ExecuteBulkInsertAsync(IEnumerable<T> records)
        {
            await dbSet.AddRangeAsync(records);
            return records;
        }

        public async Task<int> ExecuteBulkDeleteAsync(Expression<Func<T, bool>> filter)
        {
            return await dbSet.Where(filter).ExecuteDeleteAsync();
        }

        public void Update(T entity)
        {
            dbSet.Update(entity);
        }
    }
}
