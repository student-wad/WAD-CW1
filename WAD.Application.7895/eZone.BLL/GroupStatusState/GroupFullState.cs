using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eZone.DAL.DBO;

namespace eZone.BLL.GroupStatusState
{
    public class GroupFullState : IGroupProcessor
    {
        public void Process(Group group)
        {
            throw new InvalidOperationException(
                "You cannot add a student to this group since it is full");
        }
    }
}
