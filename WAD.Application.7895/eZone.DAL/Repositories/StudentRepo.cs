using eZone.DAL.DBO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eZone.DAL.Repositories
{
    public class StudentRepo : BaseRepo, IRepository<Student>
    {
        public StudentRepo(eZoneDbContext context) : base(context)
        {
        }

        public async Task CreateAsync(Student entity)
        {
            _context.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var student = await _context.Students.FindAsync(id);
            _context.Students.Remove(student);
            await _context.SaveChangesAsync();
        }

        public bool Exists(int id)
        {
            return _context.Students.Any(e => e.Id == id);
        }

        public async Task<List<Student>> GetAllAsync()
        {
            return await _context.Students.Include(s => s.Group).ToListAsync();
        }

        public async Task<Student> GetByIdAsync(int id)
        {
            return await _context.Students
                .Include(s => s.Group)
                .FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task UpdateAsync(Student entity)
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
