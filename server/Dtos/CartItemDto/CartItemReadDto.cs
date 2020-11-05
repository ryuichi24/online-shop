using server.Models;

namespace server.Dtos.CartItemDto
{
    public class CartItemReadDto
    {
        public int CartItemId { get; set; }

        public int ProductId { get; set; }

        public  virtual Product Product { get; set; }

        public int CartItemCount { get; set; }

        public int UserId { get; set; }
    }
}