﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

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
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
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
        
        [JsonIgnore]
        public virtual Course Course { get; set; }

        [JsonIgnore]
        public virtual Teacher Teacher { get; set; }

        [JsonIgnore]
        public virtual ICollection<Student> Student { get; set; }
    }
}
