using System.Linq;
using server.DataAccess;
using server.Models;

namespace server.DataAccess.Repositories.AdminRepo
{
    public class AdminRepository : Repository<Admin>, IAdminRepository
    {
        public AdminRepository(OnlineShopDbContext dbContext) : base(dbContext) {}

        public Admin GetAdminByEmail(string email)
        {
            Admin admin = base._DbContext.Set<Admin>().SingleOrDefault(a => a.Email == email);
            if(admin == null) return null;

            return admin;
        }
    }
}