using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineSurveys.Core.Models
{
    public class UserWhoTookTheSurvey
    {
        public Guid Id { get; set; }
        public string UniqueIdentifier { get; set; } //PC identifier
        public virtual ICollection<Survey> Surveus { get; set; }
 
    }
}
