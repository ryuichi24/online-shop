using System.Collections.Generic;
using server.Models;

namespace server.Dtos.User
{
    public class UserReadDto
    {
        public int UserId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public List<Address> Addresses { get; set; } = new List<Address>();

        public List<Order> Orders { get; set; } = new List<Order>();

        public List<CartItem> CartItems { get; set; } = new List<CartItem>();
    }
}