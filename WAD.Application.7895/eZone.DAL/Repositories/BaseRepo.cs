using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eZone.DAL.Repositories
{
   public abstract class BaseRepo<T>:IRepository<T> where T:class
    {
        protected readonly eZoneDbContext _context;
        internal DbSet<T> _dbSet;
        protected BaseRepo(eZoneDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }
        public async Task CreateAsync(T entity)
        {
            _context.Add(entity);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateAsync(T entity)
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(int id)
        {
            var entity = await _dbSet.FindAsync(id);
            _dbSet.Remove(entity);
            await _context.SaveChangesAsync();
        }
        public abstract bool Exists(int id);
        public abstract Task<List<T>> GetAllAsync();
        public abstract Task<T> GetByIdAsync(int id);
    }
}
