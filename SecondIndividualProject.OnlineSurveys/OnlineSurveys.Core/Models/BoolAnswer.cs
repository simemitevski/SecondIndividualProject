using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineSurveys.Core.Models
{
    public class BoolAnswer
    {
        public Guid Id { get; set; }
        public string ForTypeOfQuestion { get; set; }
        public virtual Question Question { get; set; }
        public Guid ForSurveyId { get; set; } //Id od anketata vo koja se naoga odgovorot
        public int TimesAnsweredNum { get; set; }

        public BoolAnswer()
        {
            TimesAnsweredNum = 0;
        }
    }
}
