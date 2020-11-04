using System;
using System.Collections.Generic;
using server.Models;

namespace server.Dtos.OrderDto
{
    public class OrderReadDto
    {
        public int OrderId { get; set; }

        public DateTime OrderedAt { get; set; }

        public float TotalPayment { get; set; }

        public int? AddressId { get; set; }

        public Address Address { get; set; }

        public int? UserId { get; set; }

        public User User { get; set; }

        public List<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
    }
}