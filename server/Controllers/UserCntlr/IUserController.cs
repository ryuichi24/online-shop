using Microsoft.AspNetCore.Mvc;
using server.Dtos.UserDto;
using server.Helpers.CustomResponse;
using server.Helpers.ParameterClass;

namespace server.Controllers.UserCntlr
{
    public interface IUserController
    {
        ActionResult<UserReadDto> GetUserById(int id);

        ActionResult DeleteUser(int id);

        ActionResult<SignUpUserSuccessResponse> AddNewUser([FromBody] UserCreateDto userCreateDto);

        ActionResult UpdateUser(int id, [FromBody] UserUpdateDto userUpdateDto);

        ActionResult<LoginUserSuccessResponse> LoginUser(LoginParameter loginParameter);

        ActionResult<UserReadDto> CheckUserAuth();
    }
}