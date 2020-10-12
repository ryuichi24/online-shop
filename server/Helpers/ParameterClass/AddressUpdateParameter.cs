using System.ComponentModel.DataAnnotations;

namespace server.Helpers.ParameterClass
{
    public class AddressUpdateParameter
    {
        [MaxLength(150)]
        public string Address1 { get; set; }

        [MaxLength(150)]
        public string Address2 { get; set; }

        [MaxLength(50)]
        public string City { get; set; }

        [MaxLength(50)]
        public int PostCode { get; set; }

        public int UserId { get; set; }
    }
}