using OnlineSurveys.Core.Interfaces;
using OnlineSurveys.Core.Models;

namespace OnlineSurveys.Infrastructure.Repositories
{
    public class RoleRepository : BaseRepository<Role>, IRoleRepository
    {
        public RoleRepository(OnlineSurveyContext context) : base(context)
        {
            
        }
    }
}
