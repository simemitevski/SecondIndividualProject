using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OnlineSurveys.Core.Models
{
    public class User : BaseModel
    {
        [Required]
        [Display(Name="First Name")]
        [StringLength(50, MinimumLength = 1)]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        [StringLength(50, MinimumLength = 1)]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Field can't be empty")]
        [DataType(DataType.EmailAddress, ErrorMessage = "E-mail is not valid")]
        public string Email { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
        public virtual ICollection<Role> Roles { get; set; }
        public virtual ICollection<Survey> Surveys { get; set; } 
    }
}
