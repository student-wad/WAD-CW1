﻿using System;

namespace eZone.BLL.DTO
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
