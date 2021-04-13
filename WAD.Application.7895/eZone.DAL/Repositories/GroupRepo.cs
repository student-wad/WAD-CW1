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
            /*MVC - Create*/
            /*_context.Add(entity);
            await _context.SaveChangesAsync();*/
            _context.Groups.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var group = await _context.Groups.FindAsync(id);
            _context.Groups.Remove(group);
            await _context.SaveChangesAsync();
        }

        public bool Exists(int id)
        {
            return _context.Groups.Any(e => e.Id == id);
        }

        public async Task<List<Group>> GetAllAsync()
        {
            return await _context.Groups.Include(c => c.Course).Include(t => t.Teacher).ToListAsync();
        }

        public async Task<Group> GetByIdAsync(int id)
        {
            //MVC GetById
            return await _context.Groups
                .Include(m => m.Course)
                .Include(m => m.Teacher)
                .FirstOrDefaultAsync(m => m.Id == id);
            //return await _context.Groups.FindAsync(id);
        }

        public async Task UpdateAsync(Group entity)
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
