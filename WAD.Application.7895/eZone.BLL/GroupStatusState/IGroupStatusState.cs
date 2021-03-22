using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eZone.DAL.DBO;

namespace eZone.BLL.GroupStatusState
{
   public interface IGroupStatusState
    {
        GroupStatus GroupStatus { get; }
        void Add(GroupBLL group);
        bool CanAdd(GroupBLL group);
    }
}
