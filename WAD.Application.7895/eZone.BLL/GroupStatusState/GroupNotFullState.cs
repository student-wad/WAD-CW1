using eZone.DAL.DBO;
using eZone.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eZone.BLL.GroupStatusState
{
    public class GroupNotFullState : IGroupProcessor
    {
        private IRepository<Group> _repo;

        public GroupNotFullState(IRepository<Group> repo)
        {
            _repo = repo;
        }

        public async void Process(Group group)
        {
            group.NumOfStudents++;
            await _repo.UpdateAsync(group);
        }
    }
}
