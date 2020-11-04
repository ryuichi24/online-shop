using System.ComponentModel.DataAnnotations;

namespace server.Dtos.AdminDto
{
    public class AdminUpdateDto
    {
        [MaxLength(100)]
        public string Name { get; set; }

        [MaxLength(50)]
        public string Email { get; set; }

        [MaxLength(250)]
        public string Password { get; set; }

        [MaxLength(50)]
        public string Phone { get; set; }
    }
}