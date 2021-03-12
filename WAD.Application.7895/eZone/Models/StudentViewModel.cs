using eZone.DAL.DBO;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eZone.Models
{
    public class StudentViewModel:Student
    {
        public SelectList Groups { get; set; }

        public void CopyFromStudent(Student s)
        {
            Id = s.Id;
            FirstName = s.FirstName;
            LastName = s.LastName;
            Phone = s.Phone;
            FirstLesson = s.FirstLesson;
            PaymentStatus = s.PaymentStatus;
            GroupId = s.GroupId;
        }
    }
}
