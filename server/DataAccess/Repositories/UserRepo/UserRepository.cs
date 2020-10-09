using System.Linq;
using server.Models;

namespace server.DataAccess.Repositories.UserRepo
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(OnlineShopDbContext dbContext) : base(dbContext) { }

        public User GetUserByEmail(string email)
        {
            User user = base._DbContext.Set<User>().SingleOrDefault(u => u.Email == email);
            if(user == null) return null;

            return user;
        }
    }
}