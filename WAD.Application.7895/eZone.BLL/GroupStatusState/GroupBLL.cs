using eZone.DAL.DBO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eZone.BLL.GroupStatusState
{
    public class GroupBLL : Group
    {   
        private IGroupStatusState _groupState;

        public GroupBLL(IGroupStatusState baseState)
        {
            _groupState = baseState;
        }

        public GroupStatus Status()
        {
            return _groupState.GroupStatus;
        }

        public bool CanAdd()
        {
            return _groupState.CanAdd(this);
        }

        public void Add()
        {
            if (CanAdd())
            {
                _groupState.Add(this);
            }
        }

        public void Change(IGroupStatusState GroupState)
        {
            _groupState = GroupState;
        }
    }
}
