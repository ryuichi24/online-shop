using System.Collections.Generic;
using server.Dtos.ProductDto;

namespace Services.ProductService
{
    public interface IProductService
    {
        IEnumerable<ProductReadDto> GetAllProduct();

        ProductReadDto GetProductById(int id);

        bool DeleteProduct(int id);

        ProductReadDto AddNewProduct(ProductCreateDto productCreateDto);

        bool UpdateProduct(int id, ProductUpdateDto productUpdateDto);
    }
}