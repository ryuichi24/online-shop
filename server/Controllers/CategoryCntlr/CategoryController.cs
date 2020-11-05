using Microsoft.AspNetCore.Mvc;
using server.Helpers.ParameterClass;
using server.Models;
using server.DataAccess.Repositories.CategoryRepo;
using server.Helpers.CustomResponse;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using server.Helpers;
using AutoMapper;
using server.Dtos.CategoryDto;

namespace server.Controllers.CategoryCntlr
{
    [Authorize(Roles = AuthRole.Admin)]
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase, ICategoryController
    {
        private readonly ICategoryRepository _repository;
        private readonly IMapper _mapper;

        public CategoryController(ICategoryRepository repository, IMapper mapper)
        {
            this._repository = repository;
            this._mapper = mapper;
        }

        [HttpPost]
        public ActionResult<CategoryReadDto> AddNewCategory([FromBody] CategoryCreateDto categoryCreateDto)
        {
            var newCategory = this._mapper.Map<Category>(categoryCreateDto);

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

        [AllowAnonymous]
        [HttpGet]
        public ActionResult<IEnumerable<CategoryReadDto>> GetAllCategories()
        {
            return this.Ok(this._mapper.Map<IEnumerable<CategoryReadDto>>(this._repository.GetAll()));
        }

        [AllowAnonymous]
        [HttpGet("{id}")]
        public ActionResult<CategoryReadDto> GetCategoryById(int id)
        {
            Category category = this._repository.GetById(id);

            if (category == null) return NotFound();

            return this.Ok(this._mapper.Map<Category>(category));
        }

        [HttpPut("{id}")]
        public ActionResult UpdateCategory(int id, [FromBody] CategoryUpdateDto categoryUpdateDto)
        {
            Category existingCategory = this._repository.GetById(id);
            if (existingCategory == null) return this.NotFound();

            this._mapper.Map(categoryUpdateDto, existingCategory);

            this._repository.Update(existingCategory);
            this._repository.SaveChanges();

            return this.NoContent();
        }
    }
}