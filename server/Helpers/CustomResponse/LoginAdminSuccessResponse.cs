using server.Models;

namespace server.Helpers.CustomResponse
{
    public class LoginAdminSuccessResponse
    {
        public string Token { get; set; }

        public Admin Admin { get; set; }
    }
}