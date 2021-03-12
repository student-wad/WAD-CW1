using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eZone.Models
{
    public enum CourseLevel
    {
        IELTS,
        GeneralEnglish
    }

    public class Course
    {
        public int Id { get; set; }

        public CourseLevel CourseLevel { get; set; }

        public string CourseName { get; set; }

        public string CourseDuration { get; set; }

        public float Fee { get; set; }
    }
}
