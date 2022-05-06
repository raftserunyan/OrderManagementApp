using Microsoft.EntityFrameworkCore;
using OrderManagementApp.Data.Interfaces.Common;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OrderManagementApp.Data.Repositories.Common
{
    internal class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly OrderManagementAppDbContext _context;

        public BaseRepository(OrderManagementAppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(T entity)
        {
            await _context.AddAsync(entity);
        }

        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T> GetFirstOrDefaultAsync(Expression<Func<T, bool>> predicate)
        {
            return await _context.Set<T>().FirstOrDefaultAsync(predicate);
        }
    }
}
