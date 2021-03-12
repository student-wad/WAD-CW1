using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace eZone.Models
{
    public enum GroupDays
    {
        [Description("Mon/Wed/Fri")]
        Odd,
        [Description("Tue/Thu/Sat")]
        Even
    }

    public enum GroupLevel
    {
        L1,
        L2,
        L3
    }

    public enum GroupTime
    {
        [Description("9:00 - 11:00")]
        _9am,
        [Description("11:00 - 13:00")]
        _11am,
        [Description("15:00 - 17:00")]
        _3pm,
        [Description("17:00 - 19:00")]
        _5pm,
        [Description("19:00 - 21:00")]
        _7pm
    }

    public enum PaymentStatus
    {
        Paid,
        [Description("Not Paid")]
        Not_Paid
    }
}
