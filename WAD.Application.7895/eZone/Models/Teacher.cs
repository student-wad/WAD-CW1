using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eZone.Models
{
    public class Teacher
    {
        public int Id { get; set; }

        public int FirstName { get; set; }

        public int LastName { get; set; }

        public DateTime DoB { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public double IELTS_Score { get; set; }
    }
}
