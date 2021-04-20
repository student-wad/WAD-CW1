using eZone.DAL.DBO;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eZone.DAL.Repositories
{
    public class TeacherRepo : BaseRepo<Teacher>
    {
        public TeacherRepo(eZoneDbContext context) : base(context)
        {
        }       
        public override bool Exists(int id)
        {
            return _context.Teachers.Any(e => e.Id == id);
        }
        public override async Task<List<Teacher>> GetAllAsync()
        {
            return await _context.Teachers.ToListAsync();
        }
        public override async Task<Teacher> GetByIdAsync(int id)
        {
            return await _context.Teachers.FindAsync(id);
        }        
    }
}
