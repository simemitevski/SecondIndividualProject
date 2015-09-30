using System;
using System.Collections.Generic;

namespace OnlineSurveys.Core.Models
{
    public class UserWhoTookTheSurvey : BaseModel
    {
        public string UniqueIdentifier { get; set; } //PC identifier
        public virtual ICollection<Survey> Surveus { get; set; }
    }
}
