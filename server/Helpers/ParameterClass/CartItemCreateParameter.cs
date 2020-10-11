using System.ComponentModel.DataAnnotations;

namespace server.Helpers.ParameterClass
{
    public class CartItemCreateParameter
    {
        [Required]
        public int ProductId { get; set; }

        [Required]
        public int UserId { get; set; }

        public int CartItemCount { get; set; }
    }
}