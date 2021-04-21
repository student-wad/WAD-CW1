using eZone.DAL.DBO;
using eZone.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eZone.BLL.GroupStatusState
{
    public class GroupStudentCount : Group
    {
        private readonly IGroupProcessor _groupProcessor;

        private readonly Group _group;

        public GroupStudentCount(IRepository<Group> repo, Group group)
        {
            _group = group;
            _groupProcessor = group.NumOfStudents >= 6 ? new GroupFullState() : new GroupNotFullState(repo);
        }
        public void IncrementStudentCount()
        {
            _groupProcessor.Process(_group);
        }
    }
}
