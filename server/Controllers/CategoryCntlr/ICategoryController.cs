using Microsoft.AspNetCore.Mvc;
using server.Helpers.CustomResponse;
using server.Helpers.ParameterClass;
using server.Models;

namespace server.Controllers.CategoryCntlr
{
    public interface ICategoryController
    {
        public ActionResult<AddCategorySuccessResponse> AddNewCategory([FromBody] CategoryCreateParameter categoryCreateParameter);

        public ActionResult UpdateCategory(int id, [FromBody] CategoryUpdateParameter categoryUpdateParameter);
    }
}