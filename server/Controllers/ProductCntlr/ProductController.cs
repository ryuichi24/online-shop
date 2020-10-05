using Microsoft.AspNetCore.Mvc;
using server.Helpers.ParameterClass;
using server.Models;
using server.Repositories.ProductRepo;

namespace server.Controllers.ProductCntlr
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : RootController<Product, IProductRepository>, IProductController
    {
        public ProductController(IProductRepository repository) : base(repository) { }

        [HttpPost]
        public ActionResult<Product> AddNewEntity([FromBody] ProductCreateParameter productCreateParameter)
        {
            throw new System.NotImplementedException();
        }

        [HttpPut("{id}")]
        public ActionResult UpdateEntity(int id, [FromBody] ProductUpdateParameter productUpdateParameter)
        {
            throw new System.NotImplementedException();
        }
    }
}