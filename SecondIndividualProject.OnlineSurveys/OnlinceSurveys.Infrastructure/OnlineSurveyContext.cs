using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineSurveys.Core.Models;

namespace OnlineSurveys.Infrastructure
{
    public class OnlineSurveyContext : DbContext
    {
        public OnlineSurveyContext() : base()
        {
            
        }
        public OnlineSurveyContext(string connectionString) : base(connectionString)
        {
                
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Survey> Surveys { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<UserWhoTookTheSurvey> ExternalUsers { get; set; } //Users Who Took The Survey
        public DbSet<TextAnswer> TextAnswers { get; set; }
        public DbSet<BoolAnswer> BoolAnswers { get; set; }
        public DbSet<MatrixRatingAnswer> MatrixRatingAnswers { get; set; }
        public DbSet<StarRatingAnswer> StarRatingAnswer { get; set; }
    }   
}
