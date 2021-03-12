using eZone.DAL.DBO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eZone.DAL.Repositories
{
    public class GroupRepo : BaseRepo, IRepository<Group>
    {
        public GroupRepo(eZoneDbContext context) : base(context)
        {
        }

        public async Task CreateAsync(Group entity)
        {
            _context.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var group = await _context.Groups
                .Include(m => m.Course)
                .Include(m => m.Teacher)
                .FirstOrDefaultAsync(m => m.Id == id);
        }

        public bool Exists(int id)
        {
            return _context.Groups.Any(e => e.Id == id);
        }

        public async Task<List<Group>> GetAllAsync()
        {
            return await _context.Groups.Include(m => m.Course).Include(m => m.Teacher).ToListAsync();
        }

        public async Task<Group> GetByIdAsync(int id)
        {
            return await _context.Groups
                .Include(m => m.Course)
                .Include(m => m.Teacher)
                .FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task UpdateAsync(Group entity)
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
