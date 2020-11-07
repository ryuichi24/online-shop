namespace Dtos.OrderDto
{
    public class OrderItemCreateDto
    {
        public int OrderItemCount { get; set; }

        public int OrderId { get; set; }

        public int ProductId { get; set; }
    }
}