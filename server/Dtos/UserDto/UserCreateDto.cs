using System.ComponentModel.DataAnnotations;

namespace server.Dtos.UserDto
{
    public class UserCreateDto
    {
        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }

        [Required]
        [MaxLength(50)]
        public string Email { get; set; }

        [Required]
        [MaxLength(250)]
        public string Password { get; set; }

        [MaxLength(50)]
        public string Phone { get; set; }
    }
}