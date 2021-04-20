using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace eZone.DAL.DBO
{
    public class Student:Person
    {
        [Required]
        [DisplayName("First Lesson")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime FirstLesson { get; set; }

        [Required]
        [DisplayName("Payment Status")]
        public PaymentStatus PaymentStatus { get; set; }

        [DisplayName("Group id")]
        public int? GroupId { get; set; }

        [JsonIgnore]
        public virtual Group Group { get; set; }
    }
}
