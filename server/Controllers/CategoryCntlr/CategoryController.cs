using Microsoft.AspNetCore.Mvc;
using server.Helpers.ParameterClass;
using server.Models;
using server.DataAccess.Repositories.CategoryRepo;
using server.Helpers.CustomResponse;

namespace server.Controllers.CategoryCntlr
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : RootController<Category, ICategoryRepository>, ICategoryController
    {
        public CategoryController(ICategoryRepository repository) : base(repository) { }

        [HttpPost]
        public ActionResult<AddCategorySuccessResponse> AddNewCategory([FromBody] CategoryCreateParameter categoryCreateParameter)
        {
            Category newCategory = new Category()
            {
                Name = categoryCreateParameter.Name
            };

            this._repository.Add(newCategory);
            this._repository.SaveChanges();

            return this.CreatedAtRoute(new { Id = newCategory.CategoryId }, new AddCategorySuccessResponse { Category = newCategory });
        }

        [HttpPut("{id}")]
        public ActionResult UpdateCategory(int id, [FromBody] CategoryUpdateParameter categoryUpdateParameter)
        {
            Category existingCategory = this._repository.GetById(id);
            if (existingCategory == null) return this.NotFound();

            if (categoryUpdateParameter.Name != null) existingCategory.Name = categoryUpdateParameter.Name;

            this._repository.Update(existingCategory);
            this._repository.SaveChanges();

            return this.NoContent();
        }
    }
}