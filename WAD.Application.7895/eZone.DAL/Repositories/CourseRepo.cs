using eZone.DAL.DBO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eZone.DAL.Repositories
{
    public class CourseRepo : BaseRepo, IRepository<Course>
    {
        public CourseRepo(eZoneDbContext context) : base(context)
        {
        }

        public async Task CreateAsync(Course entity)
        {
            //MVC
            /*_context.Add(entity);
            await _context.SaveChangesAsync();*/
            _context.Courses.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var course = await _context.Courses.FindAsync(id);
            _context.Courses.Remove(course);
            await _context.SaveChangesAsync();
        }

        public bool Exists(int id)
        {
            return _context.Courses.Any(e => e.Id == id);
        }

        public async Task<List<Course>> GetAllAsync()
        {
           return await _context.Courses.ToListAsync();
        }

        public async Task<Course> GetByIdAsync(int id)
        {
            //MVC
            /*return await _context.Courses
                .FirstOrDefaultAsync(m => m.Id == id);*/
           return await _context.Courses.FindAsync(id);
        }

        public async Task UpdateAsync(Course entity)
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
