using Microsoft.AspNetCore.Mvc;
using server.Helpers.ParameterClass;
using server.Models;

namespace server.Controllers.ProductCntlr
{
    public interface IProductController
    {
        public ActionResult<Product> AddNewProduct([FromBody] ProductCreateParameter productCreateParameter);

        public ActionResult UpdateProduct(int id, [FromBody] ProductUpdateParameter productUpdateParameter);
    }
}