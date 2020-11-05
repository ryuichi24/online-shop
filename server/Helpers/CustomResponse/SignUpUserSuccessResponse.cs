using server.Dtos.UserDto;
using server.Models;

namespace server.Helpers.CustomResponse
{
    public class SignUpUserSuccessResponse
    {
        public string Token { get; set; }

        public UserReadDto UserReadDto { get; set; }
    }
}