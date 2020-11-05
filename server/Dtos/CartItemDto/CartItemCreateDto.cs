using System.ComponentModel.DataAnnotations;

namespace server.Dtos.CartItemDto
{
    public class CartItemCreateDto
    {
        [Required]
        public int ProductId { get; set; }

        [Required]
        public int CartItemCount { get; set; }

        [Required]
        public int UserId { get; set; }
    }
}