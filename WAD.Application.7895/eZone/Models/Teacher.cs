using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eZone.Models
{
    public class Teacher
    {
        [Required]
        [DisplayName("Date of birth")]
        public DateTime DoB { get; set; }        

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [Range(7.5, 8.5)]
        [DisplayName("IELTS Score")]
        public double IELTS_Score { get; set; }
    }
}
