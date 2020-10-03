using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace server.Models
{
    public class Product
    {
        [Key]
        public int ProdcutId { get; set; }

        [Required]
        [MaxLength(150)]
        public int Name { get; set; }

        [Required]
        public float Price { get; set; }

        [MaxLength(250)]
        public string Description { get; set; }

        public int CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        public Category Category { get; set; }
    }
}