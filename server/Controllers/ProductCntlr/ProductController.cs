using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using server.Helpers;
using server.Dtos.ProductDto;
using Services.ProductService;

namespace server.Controllers.ProductCntlr
{
    [Authorize(Roles = AuthRole.Admin)]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase, IProductController
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            this._productService = productService;
        }

        [HttpPost]
        public ActionResult<ProductReadDto> AddNewProduct([FromBody] ProductCreateDto productCreateDto)
        {
            var productReadDto = this._productService.AddNewProduct(productCreateDto);
            if (productReadDto == null) return this.BadRequest();

            return this.CreatedAtRoute(new { Id = productReadDto.ProductId }, productReadDto);
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteProduct(int id)
        {
            var isDeleted = this._productService.DeleteProduct(id);
            if (!isDeleted) return this.BadRequest();

            return this.NoContent();
        }

        [AllowAnonymous]
        [HttpGet]
        public ActionResult<IEnumerable<ProductReadDto>> GetAllProduct()
        {
            var productReadDtos = this._productService.GetAllProduct();
            if (productReadDtos == null) return this.NotFound();

            return this.Ok(productReadDtos);
        }

        [AllowAnonymous]
        [HttpGet("{id}")]
        public ActionResult<ProductReadDto> GetProductById(int id)
        {
            var productReadDto = this._productService.GetProductById(id);
            if (productReadDto == null) return this.NotFound();

            return this.Ok(productReadDto);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateProduct(int id, [FromBody] ProductUpdateDto productUpdateDto)
        {
            var isUpdated = this._productService.UpdateProduct(id, productUpdateDto);
            if (!isUpdated) return this.BadRequest();

            return this.NoContent();
        }
    }
}