using System.ComponentModel.DataAnnotations;

namespace server.Dtos.UserDto
{
    public class UserUpdateDto
    {
        [MaxLength(50)]
        public string FirstName { get; set; }

        [MaxLength(50)]
        public string LastName { get; set; }

        [MaxLength(50)]
        public string Email { get; set; }

        public string Password { get; set; }

        [MaxLength(50)]
        public string Phone { get; set; }
    }
}