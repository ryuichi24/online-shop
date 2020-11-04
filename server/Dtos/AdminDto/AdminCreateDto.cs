using System.ComponentModel.DataAnnotations;

namespace server.Dtos.AdminDto
{
    public class AdminCreateDto
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

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