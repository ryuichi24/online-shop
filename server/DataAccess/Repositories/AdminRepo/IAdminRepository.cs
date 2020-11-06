using server.Models;

namespace server.DataAccess.Repositories.AdminRepo
{
    public interface IAdminRepository : IRepository<Admin>
    {
        // add some features specially for Admin
        Admin GetAdminByEmail(string email);
    }
}