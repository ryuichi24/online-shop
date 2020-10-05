using System.ComponentModel.DataAnnotations;

namespace server.Helpers.ParameterClass
{
    public class CategoryUpdateParameter
    {
        [MaxLength(50)]
        public string Name { get; set; }
    }
}