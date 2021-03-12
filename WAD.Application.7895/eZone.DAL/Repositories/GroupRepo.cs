using eZone.DAL.DBO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eZone.DAL.Repositories
{
    public class GroupRepo : BaseRepo, IRepository<Group>
    {
        public GroupRepo(eZoneDbContext context) : base(context)
        {
        }

        public Task CreateAsync(Group entity)
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

        public Task<List<Group>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Group> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Group entity)
        {
            throw new NotImplementedException();
        }
    }
}
