using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
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
        [Range(0, int.MaxValue)]
        public int Id { get; set; }

        [Required]
        [DisplayName("Course Level")]
        public CourseLevel CourseLevel { get; set; }

        [Required]
        [MinLength(5)]
        [DisplayName("Course Name")]
        public string CourseName { get; set; }

        [Required]
        [DisplayName("Course Duration")]
        public string CourseDuration { get; set; }

        [Required]
        [Range(0, float.MaxValue)]
        public float Fee { get; set; }

        public virtual ICollection<Group> Group { get; set; }
    }
}
