using System;
using System.Collections.Generic;
using Dtos.OrderDto;
using server.Dtos.AddressDto;
using server.Dtos.UserDto;
using server.Models;

namespace server.Dtos.OrderDto
{
    public class OrderReadDto
    {
        public int OrderId { get; set; }

        public DateTime OrderedAt { get; set; }

        public float TotalPayment { get; set; }

        public int? AddressId { get; set; }

        public AddressReadDto Address { get; set; }

        public int? UserId { get; set; }

        public UserReadDto User { get; set; }

        public List<OrderItemReadDto> OrderItems { get; set; } = new List<OrderItemReadDto>();
    }
}