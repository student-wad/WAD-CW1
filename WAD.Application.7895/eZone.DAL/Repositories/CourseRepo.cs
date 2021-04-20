using eZone.DAL.DBO;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eZone.DAL.Repositories
{
    public class CourseRepo : BaseRepo<Course>
    {
        public CourseRepo(eZoneDbContext context) : base(context)
        {
        }
        public override bool Exists(int id)
        {
            return _context.Courses.Any(e => e.Id == id);
        }
        public override async Task<List<Course>> GetAllAsync()
        {
           return await _context.Courses.ToListAsync();
        }
        public override async Task<Course> GetByIdAsync(int id)
        {
            return await _context.Courses.FindAsync(id);
        }
    }
}
