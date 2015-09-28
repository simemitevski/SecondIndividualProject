using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineSurveys.Core.Models
{
    public class Question
    {
        public Guid Id { get; protected set; }
        public string TxtQuestion { get; set; }
        public string TypeOfQuestion { get; set; }
        public virtual Survey Survey { get; set; }
    }
}
