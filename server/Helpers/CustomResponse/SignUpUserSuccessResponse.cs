using server.Dtos.UserDto;

namespace server.Helpers.CustomResponse
{
    public class SignUpUserSuccessResponse
    {
        public string Token { get; set; }

        public UserReadDto User { get; set; }
    }
}