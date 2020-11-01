using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using server.Dtos.Admin;
using server.Helpers.CustomResponse;
using server.Helpers.ParameterClass;
using server.Models;

namespace server.Controllers.AdminCntlr
{
    public interface IAdminController
    {
        // TODO: for future feature managing multiple admins with different permissions
        public ActionResult<IEnumerable<AdminReadDto>> GetAllAdmin();

        public ActionResult<AdminReadDto> GetAdminById(int id);

        public ActionResult DeleteAdmin(int id);

        public ActionResult<AdminReadDto> AddNewAdmin([FromBody] AdminCreateDto adminCreateDto);

        public ActionResult UpdateAdmin(int id, [FromBody] AdminUpdateDto adminUpdateDto);

        public ActionResult<LoginAdminSuccessResponse> LoginAdmin(LoginParameter loginParameter);

        public ActionResult<AdminReadDto> CheckAdminAuth();
    }
}