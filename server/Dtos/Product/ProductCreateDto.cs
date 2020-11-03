using System.ComponentModel.DataAnnotations;

namespace server.Dtos.Product
{
    public class ProductCreateDto
    {
        [Required]
        [MaxLength(150)]
        public string Name { get; set; }

        [Required]
        public float Price { get; set; }

        [MaxLength(1000)]
        public string Description { get; set; }

        [Required]
        public int Inventory { get; set; }

        public string Image { get; set; }

        public int CategoryId { get; set; }
    }
}