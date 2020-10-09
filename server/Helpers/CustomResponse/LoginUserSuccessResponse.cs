using server.Models;

namespace server.Helpers.CustomResponse
{
    public class LoginUserSuccessResponse
    {
        public string Token { get; set; }

        public User User { get; set; }
    }
}