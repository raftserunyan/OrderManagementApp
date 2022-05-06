using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OrderManagementApp.Data.Interfaces.Common
{
    public interface IBaseRepository<T> where T : class
    {
        Task AddAsync(T entity);
        void Delete(T entity);
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetFirstOrDefaultAsync(Expression<Func<T, bool>> predicate);
    }
}
