using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using server.Helpers.ParameterClass;
using server.Models;

namespace server.Controllers.ProductCntlr
{
    public interface IProductController
    {
        public ActionResult<IEnumerable<Product>> GetAllProduct();

        public ActionResult<Product> GetProductById(int id);

        public ActionResult DeleteProduct(int id);

        public ActionResult<Product> AddNewProduct([FromBody] ProductCreateParameter productCreateParameter);

        public ActionResult UpdateProduct(int id, [FromBody] ProductUpdateParameter productUpdateParameter);
    }
}