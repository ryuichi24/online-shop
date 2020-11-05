using System.Collections.Generic;
using System.Security.Claims;
using server.Dtos.UserDto;
using server.Helpers.CustomResponse;
using server.Helpers.ParameterClass;

namespace server.Services.UserService
{
    public interface IUserService
    {
        UserReadDto GetUserById(int id);

        UserReadDto AddNewUser(UserCreateDto userCreateDto);

        bool UpdateUser(int id, UserUpdateDto userUpdateDto);

        bool DeleteUser(int id);

        UserReadDto LoginUser(LoginParameter loginParameter);

        UserReadDto CheckUserAuth(IEnumerable<Claim> claims);
    }
}