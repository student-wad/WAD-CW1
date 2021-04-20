using System;

namespace eZone.DTO
{
    public class GroupDTO
    {
        public int Id { get; set; }

        public string GroupLevel { get; set; }
       
        public string LessonDays { get; set; }

        public string GroupTime { get; set; }
        
        public DateTime StartDate { get; set; }

        public string GroupStatus { get; set; }

        public int NumOfStudents { get; set; }

        public string CourseName { get; set; }
        
        public string TeacherFirstName { get; set; }
    }
}
