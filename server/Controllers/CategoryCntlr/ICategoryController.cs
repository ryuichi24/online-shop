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
        ActionResult<IEnumerable<CategoryReadDto>> GetAllCategories();

        ActionResult<CategoryReadDto> GetCategoryById(int id);

        ActionResult DeleteCategory(int id);

        ActionResult<CategoryReadDto> AddNewCategory([FromBody] CategoryCreateDto categoryCreateDto);

        ActionResult UpdateCategory(int id, [FromBody] CategoryUpdateDto categoryUpdateDto);
    }
}