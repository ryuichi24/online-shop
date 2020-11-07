using System.Collections.Generic;
using server.Models;

namespace server.Dtos.UserDto
{
    public class UserReadDto
    {
        public int UserId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }
    }
}