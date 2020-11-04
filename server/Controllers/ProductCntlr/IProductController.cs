using System.Collections.Generic;
using server.Dtos.ProductDto;
using Microsoft.AspNetCore.Mvc;
using server.Helpers.ParameterClass;

namespace server.Controllers.ProductCntlr
{
    public interface IProductController
    {
        public ActionResult<IEnumerable<ProductReadDto>> GetAllProduct();

        public ActionResult<ProductReadDto> GetProductById(int id);

        public ActionResult DeleteProduct(int id);

        public ActionResult<ProductReadDto> AddNewProduct([FromBody] ProductCreateDto productCreateDto);

        public ActionResult UpdateProduct(int id, [FromBody] ProductUpdateDto productUpdateDto);
    }
}
