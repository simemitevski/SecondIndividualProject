using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OnlineSurveys.Core.Models
{
    public class Survey
    {
        public Guid Id { get; protected set; }

        [Required]
        [StringLength(50, MinimumLength = 1)]
        public string Title { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 1)]
        public string Description { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 1)]
        public string Publisher { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 1)]
        public string Purpose { get; set; }

        [DataType(DataType.Date), Display(Name = "Date Created")]
        public DateTime DateCreated { get; set; }

        [DataType(DataType.Date), Display(Name = "Valid Until")]
        public DateTime ValidUntil { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<UserWhoTookTheSurvey> UsersWhoTookSurvey { get; set; }
        public virtual ICollection<Question> Questions { get; set; }

    }
}
