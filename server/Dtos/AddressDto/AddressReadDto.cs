namespace server.Dtos.AddressDto
{
    public class AddressReadDto
    {
        public int AddressId { get; set; }

        public string Address1 { get; set; }

        public string Address2 { get; set; }

        public string City { get; set; }

        public string PostCode { get; set; }

        public int UserId { get; set; }
    }
}