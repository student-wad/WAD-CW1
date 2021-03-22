using eZone.DAL.DBO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eZone.BLL.GroupStatusState
{
    public class GroupAvailableState : IGroupStatusState
    {
        public GroupStatus GroupStatus
        {
            get {return GroupStatus.Available; }
        }

        public void Add(GroupBLL group)
        {
            if (group.NumOfStudents < 12)
            {
                group.GroupStatus = GroupStatus.Available;
            }
            else
            {
                group.Change(new GroupFullState());
            }
        }

        public bool CanAdd(GroupBLL group)
        {
           return true;
        }
    }
}
