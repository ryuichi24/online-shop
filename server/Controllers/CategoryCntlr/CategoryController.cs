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

        /// <summary>
        /// add a new category
        /// </summary>
        /// <param name="categoryCreateDto"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult<CategoryReadDto> AddNewCategory([FromBody] CategoryCreateDto categoryCreateDto)
        {
            var categoryReadDto = this._categoryService.AddNewCategory(categoryCreateDto);
            if (categoryReadDto == null) return this.BadRequest();

            return this.CreatedAtRoute(new { Id = categoryReadDto.CategoryId }, categoryReadDto);
        }

        /// <summary>
        /// delete a category by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public ActionResult DeleteCategory(int id)
        {
            var isDeleted = this._categoryService.DeleteCategory(id);
            if (!isDeleted) return this.BadRequest();

            return this.NoContent();
        }

        /// <summary>
        /// get all categories
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpGet]
        public ActionResult<IEnumerable<CategoryReadDto>> GetAllCategories()
        {
            var categoryReadDtos = this._categoryService.GetAllCategories();
            if (categoryReadDtos == null) return this.NotFound();

            return this.Ok(categoryReadDtos);
        }

        /// <summary>
        /// get a category by category Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpGet("{id}")]
        public ActionResult<CategoryReadDto> GetCategoryById(int id)
        {
            var categoryReadDto = this._categoryService.GetCategoryById(id);
            if (categoryReadDto == null) return this.NotFound();

            return this.Ok(categoryReadDto);
        }

        /// <summary>
        /// update a category
        /// </summary>
        /// <param name="id"></param>
        /// <param name="categoryUpdateDto"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public ActionResult UpdateCategory(int id, [FromBody] CategoryUpdateDto categoryUpdateDto)
        {
            var isUpdated = this._categoryService.UpdateCategory(id, categoryUpdateDto);
            if (!isUpdated) return this.BadRequest();

            return this.NoContent();
        }
    }
}