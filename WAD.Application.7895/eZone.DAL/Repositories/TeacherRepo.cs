using eZone.DAL.DBO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eZone.DAL.Repositories
{
    public class TeacherRepo : BaseRepo, IRepository<Teacher>
    {
        public TeacherRepo(eZoneDbContext context) : base(context)
        {
        }

        public async Task CreateAsync(Teacher entity)
        {
            _context.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var teacher = await _context.Teachers
                 .FirstOrDefaultAsync(m => m.Id == id);
        }

        public bool Exists(int id)
        {
            return _context.Teachers.Any(e => e.Id == id);
        }

        public async Task<List<Teacher>> GetAllAsync()
        {
            return await _context.Teachers.ToListAsync();
        }

        public async Task<Teacher> GetByIdAsync(int id)
        {
            return await _context.Teachers
                .FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task UpdateAsync(Teacher entity)
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
