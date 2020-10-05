using Microsoft.AspNetCore.Mvc;
using server.Helpers.ParameterClass;
using server.Models;

namespace server.Controllers.CategoryCntlr
{
    public interface ICategoryController
    {
        public ActionResult<Category> AddNewCategory([FromBody] CategoryCreateParameter categoryCreateParameter);

        public ActionResult UpdateCategory(int id, [FromBody] CategoryUpdateParameter categoryUpdateParameter);
    }
}