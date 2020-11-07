using server.Models;

namespace Dtos.OrderDto
{
    public class OrderItemReadDto
    {
        public int OrderItemId { get; set; }

        public int OrderItemCount { get; set; }

        public int OrderId { get; set; }

        public int ProductId { get; set; }

        public Product Product { get; set; }
    }
}