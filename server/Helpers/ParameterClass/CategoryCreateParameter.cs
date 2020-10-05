using System.ComponentModel.DataAnnotations;

namespace server.Helpers.ParameterClass
{
    public class CategoryCreateParameter
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
    }
}