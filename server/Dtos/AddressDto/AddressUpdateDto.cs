using System.ComponentModel.DataAnnotations;

namespace server.Dtos.AddressDto
{
    public class AddressUpdateDto
    {
        [MaxLength(150)]
        public string Address1 { get; set; }

        [MaxLength(150)]
        public string Address2 { get; set; }

        [MaxLength(50)]
        public string City { get; set; }

        [MaxLength(50)]
        public string PostCode { get; set; }

        public int? UserId { get; set; }
    }
}