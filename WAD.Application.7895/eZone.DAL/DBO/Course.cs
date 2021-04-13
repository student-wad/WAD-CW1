using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace eZone.DAL.DBO
{
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

        [JsonIgnore]
        public virtual ICollection<Group> Group { get; set; }
    }
}
