using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using server.Dtos.CategoryDto;
using server.Helpers.CustomResponse;
using server.Helpers.ParameterClass;
using server.Models;

namespace server.Controllers.CategoryCntlr
{
    public interface ICategoryController
    {
        public ActionResult<IEnumerable<CategoryReadDto>> GetAllCategories();

        public ActionResult<CategoryReadDto> GetCategoryById(int id);

        public ActionResult DeleteCategory(int id);

        public ActionResult<CategoryReadDto> AddNewCategory([FromBody] CategoryCreateDto categoryCreateDto);

        public ActionResult UpdateCategory(int id, [FromBody] CategoryUpdateDto categoryUpdateDto);
    }
}