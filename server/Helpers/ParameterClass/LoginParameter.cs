using System.ComponentModel.DataAnnotations;

namespace server.Helpers.ParameterClass
{
    public class LoginParameter
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}