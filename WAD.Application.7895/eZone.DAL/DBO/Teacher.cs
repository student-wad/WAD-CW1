using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace eZone.DAL.DBO
{
    public class Teacher:Person
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

        [JsonIgnore]
        public virtual ICollection<Group> Group { get; set; }
    }
}
