﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineSurveys.Core.Models
{
    public enum TypeOfQuestion
    {
        Text, MultiChoice, OneChoice, DropDownOneSelect, StarRating, MatrihRating
    }
    public class Question
    {
        public Guid Id { get; protected set; }
        public string TxtQuestion { get; set; }
        public TypeOfQuestion TypeOfQuestion { get; set; }
        public virtual Survey Survey { get; set; }
        public ICollection<TextAnswer> TxTextAnswers { get; set; }
        public ICollection<Answer> Answers { get; set; } 
    }
}
