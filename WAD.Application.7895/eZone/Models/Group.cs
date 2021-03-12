using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eZone.Models
{
    public enum GroupDays
    {
        Mon_Wed_Fri,
        Tue_Thu_Sat
    }

    public enum GroupLevel
    {
        L1,
        L2,
        L3
    }

    public enum GroupTime
    {
        _9am,
        _11am,
        _3pm,
        _5pm,
        _7pm
    }

    public class Group
    {
        public int Id { get; set; }

        public GroupLevel GroupLevel { get; set; }

        public GroupDays LessonDays { get; set; }

        public GroupTime GroupTime { get; set; }

        public DateTime StartDate { get; set; }

        public int NumOfStudents { get; set; }
    }
}
