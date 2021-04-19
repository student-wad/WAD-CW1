using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eZone.DTO
{
    public class CourseDTO
    {        
        public int Id { get; set; }

        public string CourseLevel { get; set; }
       
        public string CourseName { get; set; }
      
        public string CourseDuration { get; set; }

        public float Fee { get; set; }
    }
}
