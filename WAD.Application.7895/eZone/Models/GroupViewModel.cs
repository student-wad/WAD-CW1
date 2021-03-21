using eZone.DAL.DBO;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eZone.Models
{
    public class GroupViewModel:Group
    {
        public SelectList Courses { get; set; }

        public SelectList Teachers { get; set; }

        public void CopyFromGroup(Group g)
        {
            Id = g.Id;
            GroupLevel = g.GroupLevel;
            LessonDays = g.LessonDays;
            GroupTime = g.GroupTime;
            StartDate = g.StartDate;
            GroupStatus = g.GroupStatus;
            NumOfStudents = g.NumOfStudents;
            CourseId = g.CourseId;
            TeacherId = g.TeacherId;
        }
    }
}
