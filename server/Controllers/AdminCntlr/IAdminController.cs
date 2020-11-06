using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using server.Dtos.AdminDto;
using server.Helpers.CustomResponse;
using server.Helpers.ParameterClass;

namespace server.Controllers.AdminCntlr
{
    public interface IAdminController
    {
        ActionResult<IEnumerable<AdminReadDto>> GetAllAdmin();

        ActionResult<AdminReadDto> GetAdminById(int id);

        ActionResult DeleteAdmin(int id);

        ActionResult<AdminReadDto> AddNewAdmin([FromBody] AdminCreateDto adminCreateDto);

        ActionResult UpdateAdmin(int id, [FromBody] AdminUpdateDto adminUpdateDto);

        ActionResult<LoginAdminSuccessResponse> LoginAdmin(LoginParameter loginParameter);

        ActionResult<AdminReadDto> CheckAdminAuth();
    }
}