using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eZone.DAL.DBO
{
    public class Teacher
    {
        [Range(0, int.MaxValue)]
        public int Id { get; set; }

        [Required]
        [MinLength(2)]
        [DisplayName("First Name")]
        public int FirstName { get; set; }

        [Required]
        [MinLength(2)]
        [DisplayName("Last Name")]
        public int LastName { get; set; }

        [Required]
        [Phone]
        public string Phone { get; set; }
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

        public virtual ICollection<Group> Group { get; set; }
    }
}
