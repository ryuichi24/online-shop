using Microsoft.AspNetCore.Mvc;
using server.Models;
using server.Repositories.UserRepo;

namespace server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : RootController<User, UserRepository>
    {
        public UserController(UserRepository repository) : base(repository) { }
    }
}