using System.ComponentModel.DataAnnotations;

namespace server.Helpers.ParameterClass
{
    public class ProductUpdateParameter
    {
        [MaxLength(150)]
        public string Name { get; set; }

        public float Price { get; set; }

        [MaxLength(250)]
        public string Description { get; set; }

        public int CategoryId { get; set; }
    }
}