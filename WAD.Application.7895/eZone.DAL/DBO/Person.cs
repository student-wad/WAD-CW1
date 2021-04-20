using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace eZone.DAL.DBO
{
    public abstract class Person
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
    }
}
