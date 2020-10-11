using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using server.Helpers.CustomResponse;
using server.Helpers.ParameterClass;
using server.Models;

namespace server.Controllers.CategoryCntlr
{
    public interface ICategoryController
    {
        public ActionResult<IEnumerable<Category>> GetAllCategories();

        public ActionResult<Category> GetCategoryById(int id);

        public ActionResult DeleteCategory(int id);

        public ActionResult<Category> AddNewCategory([FromBody] CategoryCreateParameter categoryCreateParameter);

        public ActionResult UpdateCategory(int id, [FromBody] CategoryUpdateParameter categoryUpdateParameter);
    }
}