using eZone.DAL.DBO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eZone.DAL.Repositories
{
    public class StudentRepo : BaseRepo<Student>
    {
        public StudentRepo(eZoneDbContext context) : base(context)
        {
        }
        public override bool Exists(int id)
        {
            return _context.Students.Any(e => e.Id == id);
        }
        public override async Task<List<Student>> GetAllAsync()
        {
            return await _context.Students.Include(g => g.Group).ToListAsync();            
        }
        public override async Task<Student> GetByIdAsync(int id)
        {
            return await _context.Students
                .Include(g => g.Group)
                .FirstOrDefaultAsync(m => m.Id == id);            
        }
    }
}
