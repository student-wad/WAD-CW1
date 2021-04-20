using eZone.DAL.DBO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eZone.DAL.Repositories
{
    public class GroupRepo : BaseRepo<Group>
    {
        public GroupRepo(eZoneDbContext context) : base(context)
        {
        }       
        public override bool Exists(int id)
        {
            return _context.Groups.Any(e => e.Id == id);
        }
        public override async Task<List<Group>> GetAllAsync()
        {
            return await _context.Groups.Include(c => c.Course).Include(t => t.Teacher).ToListAsync();
        }
        public override async Task<Group> GetByIdAsync(int id)
        {
            return await _context.Groups
                .Include(m => m.Course)
                .Include(m => m.Teacher)
                .FirstOrDefaultAsync(m => m.Id == id);            
        }
    }
}
