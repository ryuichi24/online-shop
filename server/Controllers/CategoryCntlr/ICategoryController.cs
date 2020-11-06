using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using server.Dtos.CategoryDto;

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