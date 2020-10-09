using Microsoft.AspNetCore.Mvc;
using server.Helpers.CustomResponse;
using server.Helpers.ParameterClass;
using server.Models;

namespace server.Controllers.UserCntlr
{
    public interface IUserController
    {
        public ActionResult<User> AddNewUser([FromBody] UserCreateParameter userCreateParameter);

        public ActionResult<User> UpdateUser(int id, [FromBody] UserUpdateParameter userUpdateParameter);

        public ActionResult<LoginUserSuccessResponse> LoginUser(LoginParameter loginParameter);

        public ActionResult<User> CheckUserAuth();
    }
}