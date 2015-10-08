using System.Linq;
using OnlineSurveys.Core.Models;
using OnlineSurveys.Core.Interfaces;

namespace OnlineSurveys.Infrastructure.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(OnlineSurveyContext context) : base(context)
        {
            
        }

        public bool CheckIfExist(string email, string username)
        {
           return _context.Users.Any(u => u.Email == email || u.Username == username);
        }


        public bool IfExistUserWithTheseEmailAndPass(string email, string password)
        {
            return _context.Users.Any(u => u.Email == email && u.Password == password);
        }
    }
}
