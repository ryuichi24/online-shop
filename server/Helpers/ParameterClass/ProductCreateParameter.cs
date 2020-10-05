using System.ComponentModel.DataAnnotations;

namespace server.Helpers.ParameterClass
{
    public class ProductCreateParameter
    {
        [Required]
        [MaxLength(150)]
        public string Name { get; set; }

        [Required]
        public float Price { get; set; }

        [MaxLength(250)]
        public string Description { get; set; }

        [Required]
        public int CategoryId { get; set; }
    }
}