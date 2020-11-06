using System.Collections.Generic;
using server.Dtos.ProductDto;
using Microsoft.AspNetCore.Mvc;

namespace server.Controllers.ProductCntlr
{
    public interface IProductController
    {
        ActionResult<IEnumerable<ProductReadDto>> GetAllProduct();

        ActionResult<ProductReadDto> GetProductById(int id);

        ActionResult DeleteProduct(int id);

        ActionResult<ProductReadDto> AddNewProduct([FromBody] ProductCreateDto productCreateDto);

        ActionResult UpdateProduct(int id, [FromBody] ProductUpdateDto productUpdateDto);
    }
}
