using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eZone.DAL.DBO
{
    public class Group
    {
        [Range(0, int.MaxValue)]
        public int Id { get; set; }

        [Required]
        [DisplayName("Group Level")]
        public GroupLevel GroupLevel { get; set; }

        [Required]
        [DisplayName("Lesson Days")]
        public GroupDays LessonDays { get; set; }

        [Required]
        [DisplayName("Group Time")]
        public GroupTime GroupTime { get; set; }

        [Required]
        [DisplayName("Start Date")]
        public DateTime StartDate { get; set; }

        [Required]
        [DisplayName("Group Status")]
        public GroupStatus GroupStatus { get; set; }

        [Required]
        [DisplayName("Number of Students")]
        public int NumOfStudents { get; set; }

        [DisplayName("Course")]
        public int? CourseId { get; set; }

        [DisplayName("Teacher")]
        public int? TeacherId { get; set; }
        
        public virtual Course Course { get; set; }
        
        public virtual Teacher Teacher { get; set; }

        public virtual ICollection<Student> Student { get; set; }
    }
}
