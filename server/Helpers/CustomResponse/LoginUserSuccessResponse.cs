using server.Dtos.UserDto;
using server.Models;

namespace server.Helpers.CustomResponse
{
    public class LoginUserSuccessResponse
    {
        public string Token { get; set; }

        public UserReadDto User { get; set; }
    }
}