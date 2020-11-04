namespace server.Dtos.ProductDto
{
    public class ProductReadDto
    {
        public int ProductId { get; set; }

        public string Name { get; set; }

        public float Price { get; set; }

        public string Description { get; set; }

        public int Inventory { get; set; }

        public string Image { get; set; }

        public int CategoryId { get; set; }
    }
}