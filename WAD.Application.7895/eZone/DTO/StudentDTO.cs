using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eZone.DTO
{
    public class StudentDTO
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Phone { get; set; }
        public DateTime FirstLesson { get; set; }

        public string PaymentStatus { get; set; }

        public int GroupId { get; set; }        
    }
}
