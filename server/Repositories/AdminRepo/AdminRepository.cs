using server.DataAccess;
using server.Models;

namespace server.Repositories.AdminRepo
{
    public class AdminRepository : Repository<Admin>, IAdminRepository
    {
        // dependency injection
        public AdminRepository(OnlineShopDbContext dbContext) : base(dbContext) {}
    }
}