using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace server.Models
{
    public class CartItem
    {
        [Key]
        public int CardItemId { get; set; }

        public int ProductId { get; set; }

        [ForeignKey("ProductId")]
        public  virtual Product Product { get; set; }

        public int CartItemCount { get; set; }

        public int UserId { get; set; }

        [JsonIgnore]
        [ForeignKey("UserId")]
        public virtual User User { get; set; }
    }
}