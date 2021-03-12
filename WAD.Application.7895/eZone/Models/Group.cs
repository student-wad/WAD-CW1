using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
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
        [DisplayName("Number of Students")]
        public int NumOfStudents { get; set; }

        public int? CourseId { get; set; }

        public int? TeacherId { get; set; }
        
        public virtual Course Course { get; set; }
        
        public virtual Teacher Teacher { get; set; }

        public virtual ICollection<Student> Student { get; set; }
    }
}
