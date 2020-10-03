using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace server.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

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
        public int Phone { get; set; }

        public List<Address> Addresses { get; set; } = new List<Address>();

        public List<Order> Orders { get; set; } = new List<Order>();

        public List<CartItem> CartItems { get; set; } = new List<CartItem>();

    }

}