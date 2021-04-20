using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eZone.DAL.Repositories
{
    public abstract class BaseRepo<T>:IRepository<T> where T:class
    {
        protected readonly eZoneDbContext _context;        
        protected BaseRepo(eZoneDbContext context)
        {
            _context = context;           
        }
        public async Task CreateAsync(T entity)
        {
            _context.Set<T>().Add(entity);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateAsync(T entity)
        {
            _context.Set<T>().Update(entity);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(int id)
        {
            var entity = await _context.Set<T>().FindAsync(id);
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
        }
        public abstract bool Exists(int id);
        public abstract Task<List<T>> GetAllAsync();
        public abstract Task<T> GetByIdAsync(int id);
    }
}
