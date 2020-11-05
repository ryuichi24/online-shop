using System.ComponentModel.DataAnnotations;

namespace server.Dtos.CategoryDto
{
    public class CategoryCreateDto
    {
        [Required]
        public string Name { get; set; }
    }
}