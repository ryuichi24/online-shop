using Microsoft.AspNetCore.Mvc;
using server.Helpers.ParameterClass;
using server.Models;

namespace server.Controllers.AdminCntlr
{
    public interface IAdminController
    {
        public ActionResult<Admin> AddNewEntity([FromBody] AdminParameter adminParameter);

        public ActionResult UpdateEntity(int id, [FromBody] AdminParameter entityToUpdate);
    }
}