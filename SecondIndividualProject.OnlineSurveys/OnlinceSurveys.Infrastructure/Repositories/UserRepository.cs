using OnlineSurveys.Core.Models;
using OnlineSurveys.Core.Interfaces;

namespace OnlinceSurveys.Infrastructure.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(OnlineSurveysDbContext context) : base(context)
        {
            
        }
    }
}
