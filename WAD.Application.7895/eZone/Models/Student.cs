using System;
using System.Collections.Generic;
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
        public int Id { get; set; }

        public int FirstName { get; set; }

        public int LastName { get; set; }

        public string Phone { get; set; }

        public DateTime FirstLesson { get; set; }

        public PaymentStatus PaymentStatus { get; set; }
    }
}
