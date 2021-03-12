using eZone.DAL.DBO;
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

        public Task CreateAsync(Student entity)
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

        public Task<List<Student>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Student> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Student entity)
        {
            throw new NotImplementedException();
        }
    }
}
