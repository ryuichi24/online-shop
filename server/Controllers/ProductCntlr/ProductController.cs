using Microsoft.AspNetCore.Mvc;
using server.Helpers.ParameterClass;
using server.Models;
using server.DataAccess.Repositories.ProductRepo;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using server.Helpers;

namespace server.Controllers.ProductCntlr
{
    [Authorize(Roles = AuthRole.Admin)]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase, IProductController
    {
        private readonly IProductRepository _repository;

        public ProductController(IProductRepository repository)
        {
            this._repository = repository;
        }

        [HttpPost]
        public ActionResult<Product> AddNewProduct([FromBody] ProductCreateParameter productCreateParameter)
        {
            Product newProduct = new Product()
            {
                Name = productCreateParameter.Name,
                Price = productCreateParameter.Price,
                Description = productCreateParameter.Description,
                Inventory = productCreateParameter.Inventory,
                CategoryId = productCreateParameter.CategoryId,
                Image = productCreateParameter.Image
            };

            this._repository.Add(newProduct);
            this._repository.SaveChanges();

            return this.CreatedAtRoute(new { Id = newProduct.ProductId }, newProduct);
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
        public ActionResult<IEnumerable<Product>> GetAllProduct()
        {
            return this.Ok(this._repository.GetAll());
        }

        [AllowAnonymous]
        [HttpGet("{id}")]
        public ActionResult<Product> GetProductById(int id)
        {
            Product product = this._repository.GetById(id);

            if (product == null) return this.NotFound();

            return this.Ok(product);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateProduct(int id, [FromBody] ProductUpdateParameter productUpdateParameter)
        {
            Product existingProduct = this._repository.GetById(id);
            if (existingProduct == null) return this.NotFound();

            if (productUpdateParameter.Name != null) existingProduct.Name = productUpdateParameter.Name;
            if (productUpdateParameter.Price != null) existingProduct.Price = float.Parse(productUpdateParameter.Price.ToString());
            if (productUpdateParameter.Description != null) existingProduct.Description = productUpdateParameter.Description;
            if (productUpdateParameter.Inventory != null) existingProduct.Inventory = int.Parse(productUpdateParameter.Inventory.ToString());
            if (productUpdateParameter.Image != null) existingProduct.Image = productUpdateParameter.Image;
            if (productUpdateParameter.CategoryId != null) existingProduct.CategoryId = int.Parse(productUpdateParameter.CategoryId.ToString());

            this._repository.Update(existingProduct);
            this._repository.SaveChanges();

            return this.NoContent();
        }
    }
}