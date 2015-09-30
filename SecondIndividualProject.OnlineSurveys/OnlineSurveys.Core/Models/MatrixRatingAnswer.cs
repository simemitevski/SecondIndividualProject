using System;
using System.ComponentModel.DataAnnotations;

namespace OnlineSurveys.Core.Models
{
    public class MatrixRatingAnswer : BaseModel
    {
        public string ForTypeOfQuestion { get; set; }
        public virtual Question Question { get; set; }
        public Guid ForSurveyId { get; set; } //Id od anketata vo koja se naoga odgovorot
        public int AnswerNumber { get; set; } //Number for sorting

        [Display(Name = "Strongly Disagree")]
        public int StronglyDisagreeNum { get; set; }
        [Display(Name = "Disagree")]
        public int DisagreeNum { get; set; }
        [Display(Name = "Neutral")]
        public int NeutralNum { get; set; }
        [Display(Name = "Agree")]
        public int AgreeNum { get; set; }
        [Display(Name = "Strongly Agree")]
        public int StronglyAgreeNum { get; set; }

        public MatrixRatingAnswer()
        {
            StronglyDisagreeNum = 0;
            DisagreeNum = 0;
            NeutralNum = 0;
            AgreeNum = 0;
            StronglyAgreeNum = 0;
        }
    }
}
