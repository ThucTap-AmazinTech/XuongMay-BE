using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XuongMay_BE.Contract.Repositories.Repositories;
using XuongMay_BE.Core.Base;
using XuongMay_BE.Repositories.DataContext;

namespace XuongMay_BE.Repositories.UnitOfWork
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly DatabaseContext _context;
        protected readonly DbSet<T> _dbSet;

        public GenericRepository(DatabaseContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public IQueryable<T> Entities => _context.Set<T>();

        public async Task AddAsync(T obj)
        {
            await _dbSet.AddAsync(obj);
        }

        public Task UpdateAsync(T obj)
        {
            return Task.FromResult(_dbSet.Update(obj));
        }

        public async Task DeleteAsync(object id)
        {
            T entity = await _dbSet.FindAsync(id) ?? throw new Exception();
            _dbSet.Remove(entity);
        }

        public async Task<IList<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T?> GetByIdAsync(object id)
        {
            return await _dbSet.FindAsync(id);
        }

        // Không gọi hàm này khi lưu lại thay đổi trong dbSet, chỉ gọi phương thức SaveAsync() của UOW
        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<BasePaginatedList<T>> GetPagging(IQueryable<T> query, int index, int pageSize)
        {
            query = query.AsNoTracking();
            int count = await query.CountAsync();
            IReadOnlyCollection<T> result = await query.Skip((pageSize - 1) * pageSize).Take(pageSize).ToListAsync();
            return new BasePaginatedList<T>(result, count, index, pageSize);
        }
    }
}
