using Microsoft.AspNetCore.Mvc;
using server.Helpers.ParameterClass;
using server.Models;
using server.DataAccess.Repositories.ProductRepo;

namespace server.Controllers.ProductCntlr
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : RootController<Product, IProductRepository>, IProductController
    {
        public ProductController(IProductRepository repository) : base(repository) { }

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

        [HttpPut("{id}")]
        public ActionResult UpdateProduct(int id, [FromBody] ProductUpdateParameter productUpdateParameter)
        {
            Product existingProduct = this._repository.GetById(id);
            if (existingProduct == null) return this.NotFound();

            if (productUpdateParameter.Name != null) existingProduct.Name = productUpdateParameter.Name;
            if (!productUpdateParameter.Price.Equals(null)) existingProduct.Price = productUpdateParameter.Price;
            if (productUpdateParameter.Description != null) existingProduct.Description = productUpdateParameter.Description;
            if (!productUpdateParameter.Inventory.Equals(null)) existingProduct.Inventory = productUpdateParameter.Inventory;
            if (productUpdateParameter.Image != null) existingProduct.Image = productUpdateParameter.Image;
            if (!productUpdateParameter.CategoryId.Equals(null)) existingProduct.CategoryId = productUpdateParameter.CategoryId;

            this._repository.Update(existingProduct);
            this._repository.SaveChanges();

            return this.NoContent();
        }
    }
}