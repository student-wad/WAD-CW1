using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eZone.DAL.DBO;

namespace eZone.BLL.GroupStatusState
{
    public class GroupFullState : IGroupStatusState
    {
        public GroupStatus GroupStatus
        {
            get { return GroupStatus.Full; }
        }

        public void Add(GroupBLL group)
        {
            throw new InvalidOperationException(
                "You cannot add a student to this group since it is full");
        }

        public bool CanAdd(GroupBLL group)
        {
            return false;
        }
    }
}
