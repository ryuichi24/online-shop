using System.ComponentModel.DataAnnotations;

namespace server.Dtos.ProductDto
{
    public class ProductUpdateDto
    {
        [MaxLength(150)]
        public string Name { get; set; }

        public float? Price { get; set; }

        [MaxLength(1000)]
        public string Description { get; set; }

        public int? Inventory { get; set; }

        public string Image { get; set; }

        public int? CategoryId { get; set; }
    }
}