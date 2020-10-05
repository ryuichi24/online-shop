using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace server.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}