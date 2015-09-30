using System;

namespace OnlineSurveys.Core.Models
{

    public class StarRatingAnswer
    {
        public Guid Id { get; set; }
        public string ForTypeOfQuestion { get; set; }
        public virtual Question Question { get; set; }
        public Guid ForSurveyId { get; set; } //Id od anketata vo koja se naoga odgovorot
        public int AnswerNumber { get; set; } //Number for sorting

        public int NumberOfOneStars { get; set; }
        public int NumberOfTwoStars { get; set; }
        public int NumberOfThreeStars { get; set; }
        public int NumberOfFourStars { get; set; }
        public int NumberOfFiveStars { get; set; }

        public StarRatingAnswer()
        {
            NumberOfOneStars = 0;
            NumberOfTwoStars = 0;
            NumberOfThreeStars = 0;
            NumberOfFourStars = 0;
            NumberOfFiveStars = 0;
        }
    }
}
