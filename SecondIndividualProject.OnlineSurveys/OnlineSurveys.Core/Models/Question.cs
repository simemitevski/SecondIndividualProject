using System;
using System.Collections.Generic;

namespace OnlineSurveys.Core.Models
{
    public enum TypeOfQuestion
    {
        Text, MultiChoice, OneChoice, DropDownOneSelect, StarRating, MatrihRating
    }

    public class Question : BaseModel
    {
        public string QuestionName { get; set; }
        public TypeOfQuestion TypeOfQuestion { get; set; }
        public int QuestionNumber { get; set; } //Number for sorting
        public virtual Survey Survey { get; set; }
        public ICollection<TextAnswer> TxTextAnswers { get; set; }
        public ICollection<BoolAnswer> BoolAnswers { get; set; }
        public ICollection<StarRatingAnswer> StarRatingAnswers { get; set; }
        public ICollection<MatrixRatingAnswer> MatrixRatingAnswers { get; set; } 
    }
}
