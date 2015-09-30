using System;

namespace OnlineSurveys.Core.Models
{
    public class TextAnswer : BaseModel
    {
        public string ForTypeOfQuestion { get; set; }
        public virtual Question Question { get; set; }
        public Guid ForSurveyId { get; set; } //Id od anketata vo koja se naoga odgovorot
        public DateTime DateTimeAnswered { get; set; }
        public string TxtAnswer { get; set; }
    }
}
