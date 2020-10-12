using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace server.Helpers.ParameterClass
{
    public class OrderItemCreateObject
    {
        public int ProductId { get; set; }

        public int OrderItemCount { get; set; }
    }

    public class OrderCreateParameter
    {
        [Required]
        public float TotalPayment { get; set; }

        [Required]
        public int AddressId { get; set; }

        [Required]
        public int UserId { get; set; }

        public List<OrderItemCreateObject> OrderItems { get; set; } = new List<OrderItemCreateObject>();
    }
}