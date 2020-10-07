using Microsoft.AspNetCore.Mvc;
using server.Helpers.CustomResponse;
using server.Helpers.ParameterClass;
using server.Models;

namespace server.Controllers.AdminCntlr
{
    public interface IAdminController
    {
        public ActionResult<Admin> AddNewAdmin([FromBody] AdminCreateParameter adminCreateParameter);

        public ActionResult UpdateAdmin(int id, [FromBody] AdminUpdateParameter adminUpdateParameter);

        public ActionResult<LoginAdminSuccessResponse> LoginAdmin(LoginParameter loginParameter);

        public ActionResult<Admin> CheckAdminAuth();
    }
}