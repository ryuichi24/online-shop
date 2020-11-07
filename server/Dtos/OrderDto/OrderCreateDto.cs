using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Dtos.OrderDto;

namespace server.Dtos.OrderDto
{
    public class OrderCreateDto
    {
        [Required]
        public DateTime OrderedAt { get; set; }

        [Required]
        public float TotalPayment { get; set; }

        [Required]
        public int AddressId { get; set; }

        [Required]
        public int UserId { get; set; }

        public List<OrderItemCreateDto> OrderItems { get; set; } = new List<OrderItemCreateDto>();
    }
}