using Microsoft.AspNetCore.Mvc;
using server.Helpers.ParameterClass;
using server.Models;

namespace server.Controllers.ProductCntlr
{
    public interface IProductController
    {
        public ActionResult<Product> AddNewEntity([FromBody] ProductCreateParameter productCreateParameter);

        public ActionResult UpdateEntity(int id, [FromBody] ProductUpdateParameter productUpdateParameter);
    }
}