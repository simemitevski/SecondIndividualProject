using System;

namespace OnlineSurveys.Core.Models
{
    public class BoolAnswer : BaseModel // ch, rdbtn, ddl questions
    {
        public string ForTypeOfQuestion { get; set; }
        public virtual Question Question { get; set; }
        public Guid ForSurveyId { get; set; } //Id od anketata vo koja se naoga odgovorot
        public int TimesAnsweredNum { get; set; }
        public int AnswerNumber { get; set; } //Number for sorting

        public BoolAnswer()
        {
            TimesAnsweredNum = 0;
        }
    }
}
