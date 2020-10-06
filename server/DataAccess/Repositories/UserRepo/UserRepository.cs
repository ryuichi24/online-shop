using server.DataAccess;
using server.Models;

namespace server.DataAccess.Repositories.UserRepo
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(OnlineShopDbContext dbContext) : base(dbContext) { }
    }
}