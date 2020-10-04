using Microsoft.AspNetCore.Mvc;
using server.Models;
using server.Repositories.AdminRepo;

namespace server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : RootController<Admin, AdminRepository>
    {
        public AdminController(AdminRepository repository) : base(repository) { }
    }
}