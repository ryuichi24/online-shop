using Microsoft.AspNetCore.Mvc;
using server.Helpers.ParameterClass;
using server.Models;
using server.DataAccess.Repositories.ProductRepo;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using server.Helpers;
using server.Dtos.Product;
using AutoMapper;

namespace server.Controllers.ProductCntlr
{
    [Authorize(Roles = AuthRole.Admin)]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase, IProductController
    {
        private readonly IProductRepository _repository;
        private readonly IMapper _mapper;

        public ProductController(IProductRepository repository, IMapper mapper)
        {
            this._repository = repository;
            this._mapper = mapper;
        }

        [HttpPost]
        public ActionResult<ProductReadDto> AddNewProduct([FromBody] ProductCreateDto productCreateDto)
        {
            var newProductModel = this._mapper.Map<Product>(productCreateDto);

            this._repository.Add(newProductModel);
            this._repository.SaveChanges();

            return this.CreatedAtRoute(new { Id = newProductModel.ProductId }, newProductModel);
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteProduct(int id)
        {
            Product product = this._repository.GetById(id);
            if (product == null) return NotFound();

            this._repository.Remove(product);
            this._repository.SaveChanges();

            return this.NoContent();
        }

        [AllowAnonymous]
        [HttpGet]
        public ActionResult<IEnumerable<ProductReadDto>> GetAllProduct()
        {
            return this.Ok(this._mapper.Map<IEnumerable<ProductReadDto>>(this._repository.GetAll()));
        }

        [AllowAnonymous]
        [HttpGet("{id}")]
        public ActionResult<ProductReadDto> GetProductById(int id)
        {
            Product product = this._repository.GetById(id);

            if (product == null) return this.NotFound();

            return this.Ok(this._mapper.Map<ProductReadDto>(product));
        }

        [HttpPut("{id}")]
        public ActionResult UpdateProduct(int id, [FromBody] ProductUpdateDto productUpdateDto)
        {
            Product existingProduct = this._repository.GetById(id);
            if (existingProduct == null) return this.NotFound();

            this._mapper.Map(productUpdateDto, existingProduct);

            this._repository.Update(existingProduct);
            this._repository.SaveChanges();

            return this.NoContent();
        }
    }
}