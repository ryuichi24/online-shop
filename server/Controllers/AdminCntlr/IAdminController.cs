using Microsoft.AspNetCore.Mvc;
using server.Helpers.ParameterClass;
using server.Models;

namespace server.Controllers.AdminCntlr
{
    public interface IAdminController
    {
        public ActionResult<Admin> AddNewEntity([FromBody] AdminCreateParameter adminCreateParameter);

        public ActionResult UpdateEntity(int id, [FromBody] AdminUpdateParameter adminUpdateParameter);
    }
}