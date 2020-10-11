using Microsoft.AspNetCore.Mvc;
using server.Helpers.ParameterClass;
using server.Models;
using server.DataAccess.Repositories.CategoryRepo;
using server.Helpers.CustomResponse;
using System.Collections.Generic;

namespace server.Controllers.CategoryCntlr
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase, ICategoryController
    {
        private readonly ICategoryRepository _repository;

        public CategoryController(ICategoryRepository repository)
        {
            this._repository = repository;
        }

        [HttpPost]
        public ActionResult<Category> AddNewCategory([FromBody] CategoryCreateParameter categoryCreateParameter)
        {
            Category newCategory = new Category()
            {
                Name = categoryCreateParameter.Name
            };

            this._repository.Add(newCategory);
            this._repository.SaveChanges();

            return this.CreatedAtRoute(new { Id = newCategory.CategoryId }, newCategory);
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteCategory(int id)
        {
            Category category = this._repository.GetById(id);
            if (category == null) return NotFound();

            this._repository.Remove(category);
            this._repository.SaveChanges();

            return this.NoContent();
        }

        [HttpGet]
        public ActionResult<IEnumerable<Category>> GetAllCategories()
        {
            return this.Ok(this._repository.GetAll());
        }

        [HttpGet("{id}")]
        public ActionResult<Category> GetCategoryById(int id)
        {
            Category category = this._repository.GetById(id);

            if (category == null) return NotFound();

            return this.Ok(category);
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