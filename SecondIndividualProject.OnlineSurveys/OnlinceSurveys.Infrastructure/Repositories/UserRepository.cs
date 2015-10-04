using OnlineSurveys.Core.Models;
using OnlineSurveys.Core.Interfaces;

namespace OnlineSurveys.Infrastructure.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(OnlineSurveyContext context) : base(context)
        {
            
        }
    }
}
