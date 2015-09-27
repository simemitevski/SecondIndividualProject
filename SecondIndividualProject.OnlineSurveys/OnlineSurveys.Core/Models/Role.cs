using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OnlineSurveys.Core.Models
{
    public class Role
    {
        public Guid Id { get; protected set; }

        [Required]
        public string RoleName { get; set; }
        public virtual ICollection<User> Users { get; set; }

    }
}
