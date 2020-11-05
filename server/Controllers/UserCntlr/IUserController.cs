using Microsoft.AspNetCore.Mvc;
using server.Dtos.UserDto;
using server.Helpers.CustomResponse;
using server.Helpers.ParameterClass;

namespace server.Controllers.UserCntlr
{
    public interface IUserController
    {
        public ActionResult<UserReadDto> GetUserById(int id);

        public ActionResult DeleteUser(int id);

        public ActionResult<SignUpUserSuccessResponse> AddNewUser([FromBody] UserCreateDto userCreateDto);

        public ActionResult UpdateUser(int id, [FromBody] UserUpdateDto userUpdateDto);

        public ActionResult<LoginUserSuccessResponse> LoginUser(LoginParameter loginParameter);

        public ActionResult<UserReadDto> CheckUserAuth();
    }
}