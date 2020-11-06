using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using server.Helpers;
using server.Dtos.CategoryDto;
using Services.CategoryService;

namespace server.Controllers.CategoryCntlr
{
    [Authorize(Roles = AuthRole.Admin)]
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase, ICategoryController
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            this._categoryService = categoryService;
        }

        [HttpPost]
        public ActionResult<CategoryReadDto> AddNewCategory([FromBody] CategoryCreateDto categoryCreateDto)
        {
            var categoryReadDto = this._categoryService.AddNewCategory(categoryCreateDto);
            if (categoryReadDto == null) return this.BadRequest();

            return this.CreatedAtRoute(new { Id = categoryReadDto.CategoryId }, categoryReadDto);
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteCategory(int id)
        {
            var isDeleted = this._categoryService.DeleteCategory(id);
            if (!isDeleted) return this.BadRequest();

            return this.NoContent();
        }

        [AllowAnonymous]
        [HttpGet]
        public ActionResult<IEnumerable<CategoryReadDto>> GetAllCategories()
        {
            var categoryReadDtos = this._categoryService.GetAllCategories();
            if (categoryReadDtos == null) return this.NotFound();

            return this.Ok(categoryReadDtos);
        }

        [AllowAnonymous]
        [HttpGet("{id}")]
        public ActionResult<CategoryReadDto> GetCategoryById(int id)
        {
            var categoryReadDto = this._categoryService.GetCategoryById(id);
            if (categoryReadDto == null) return this.NotFound();

            return this.Ok(categoryReadDto);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateCategory(int id, [FromBody] CategoryUpdateDto categoryUpdateDto)
        {
            var isUpdated = this._categoryService.UpdateCategory(id, categoryUpdateDto);
            if (!isUpdated) return this.BadRequest();

            return this.NoContent();
        }
    }
}