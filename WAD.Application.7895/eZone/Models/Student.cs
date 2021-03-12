using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eZone.Models
{
    public enum PaymentStatus
    {
        Paid,
        Not_Paid
    }

    public class Student
    {
       
        [Required]
        [DisplayName("First Lesson")]
        public DateTime FirstLesson { get; set; }

        [Required]
        [DisplayName("Payment Status")]
        public PaymentStatus PaymentStatus { get; set; }
    }
}
