using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eZone.DAL.DBO
{
    public class Student
    {
        [Range(0, int.MaxValue)]
        public int Id { get; set; }

        [Required]
        [MinLength(2)]
        [DisplayName("First Name")]
        public string FirstName { get; set; }

        [Required]
        [MinLength(2)]
        [DisplayName("Last Name")]
        public string LastName { get; set; }

        [Required]
        [Phone]
        public string Phone { get; set; }

        [Required]
        [DisplayName("First Lesson")]
        public DateTime FirstLesson { get; set; }

        [Required]
        [DisplayName("Payment Status")]
        public PaymentStatus PaymentStatus { get; set; }

        public int? GroupId { get; set; }

        public virtual Group Group { get; set; }
    }
}
