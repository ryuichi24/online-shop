using server.Dtos.AdminDto;

namespace server.Helpers.CustomResponse
{
    public class LoginAdminSuccessResponse
    {
        public string Token { get; set; }

        public AdminReadDto AdminReadDto { get; set; }
    }
}