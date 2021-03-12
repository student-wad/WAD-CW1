using eZone.DAL.DBO;
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

        public Task CreateAsync(Course entity)
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

        public Task<List<Course>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Course> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Course entity)
        {
            throw new NotImplementedException();
        }
    }
}
