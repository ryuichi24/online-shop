using server.DataAccess;
using server.Models;

namespace server.Repositories.AdminRepo
{
    public class AdminRepository : Repository<Admin>, IAdminRepository
    {
        public AdminRepository(OnlineShopDbContext dbContext) : base(dbContext) {}
    }
}