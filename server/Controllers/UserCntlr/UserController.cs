using Microsoft.AspNetCore.Mvc;
using server.Models;
using server.DataAccess.Repositories.UserRepo;
using server.Helpers.ParameterClass;
using server.Helpers.CustomResponse;

namespace server.Controllers.UserCntlr
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : RootController<User, IUserRepository>, IUserController
    {
        public UserController(IUserRepository repository) : base(repository) { }

        public ActionResult<User> AddNewUser([FromBody] UserCreateParameter userCreateParameter)
        {
            throw new System.NotImplementedException();
        }

        public ActionResult<User> UpdateUser(int id, [FromBody] UserUpdateParameter userUpdateParameter)
        {
            throw new System.NotImplementedException();
        }

         public ActionResult<LoginUserSuccessResponse> LoginUser(LoginParameter loginParameter)
        {
            throw new System.NotImplementedException();
        }

          public ActionResult<User> CheckUserAuth()
        {
            throw new System.NotImplementedException();
        }
    }
}