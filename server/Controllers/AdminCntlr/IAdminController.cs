using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using server.Dtos.AdminDto;
using server.Helpers.CustomResponse;
using server.Helpers.ParameterClass;

namespace server.Controllers.AdminCntlr
{
    public interface IAdminController
    {
        public ActionResult<IEnumerable<AdminReadDto>> GetAllAdmin();

        public ActionResult<AdminReadDto> GetAdminById(int id);

        public ActionResult DeleteAdmin(int id);

        public ActionResult<AdminReadDto> AddNewAdmin([FromBody] AdminCreateDto adminCreateDto);

        public ActionResult UpdateAdmin(int id, [FromBody] AdminUpdateDto adminUpdateDto);

        public ActionResult<LoginAdminSuccessResponse> LoginAdmin(LoginParameter loginParameter);

        public ActionResult<AdminReadDto> CheckAdminAuth();
    }
}