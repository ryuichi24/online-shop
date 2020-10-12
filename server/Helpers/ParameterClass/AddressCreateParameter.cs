using System.ComponentModel.DataAnnotations;

namespace server.Helpers.ParameterClass
{
    public class AddressCreateParameter
    {
        [Required]
        [MaxLength(150)]
        public string Address1 { get; set; }

        [MaxLength(150)]
        public string Address2 { get; set; }

        [Required]
        [MaxLength(50)]
        public string City { get; set; }

        [Required]
        [MaxLength(50)]
        public int PostCode { get; set; }

        [Required]
        public int UserId { get; set; }
    }
}