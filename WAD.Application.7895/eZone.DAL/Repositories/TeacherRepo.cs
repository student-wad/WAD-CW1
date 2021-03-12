using eZone.DAL.DBO;
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

        public Task CreateAsync(Teacher entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public bool Exists(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Teacher>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Teacher> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Teacher entity)
        {
            throw new NotImplementedException();
        }
    }
}
