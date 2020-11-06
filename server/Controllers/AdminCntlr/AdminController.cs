using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using server.Helpers;
using server.Helpers.CustomResponse;
using server.Helpers.ParameterClass;
using server.Services.Auth;
using System.Collections.Generic;
using server.Dtos.AdminDto;
using Services.AdminService;

namespace server.Controllers.AdminCntlr
{
    [Authorize(Roles = AuthRole.Admin)]
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase, IAdminController
    {
        private readonly IAuthManager _authManager;

        private readonly IAdminService _adminService;

        public AdminController(IAdminService adminService, IAuthManager authManager)
        {
            this._adminService = adminService;
            this._authManager = authManager;
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult<AdminReadDto> AddNewAdmin([FromBody] AdminCreateDto adminCreateDto)
        {
            var adminReadDto = this._adminService.AddNewAdmin(adminCreateDto);
            if (adminReadDto == null) return this.BadRequest();

            return this.CreatedAtRoute(new { Id = adminReadDto.AdminId }, adminReadDto);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateAdmin(int id, [FromBody] AdminUpdateDto adminUpdateDto)
        {
            var isUpdated = this._adminService.UpdateAdmin(id, adminUpdateDto);
            if (!isUpdated) return this.BadRequest();

            return this.NoContent();
        }

        [AllowAnonymous]
        [Route("login")]
        [HttpPost]
        public ActionResult<LoginAdminSuccessResponse> LoginAdmin(LoginParameter loginParameter)
        {
            var adminReadDto = this._adminService.LoginAdmin(loginParameter);
            if (adminReadDto == null) return this.Unauthorized();

            string token = this._authManager.GenerateJwt(adminReadDto.AdminId.ToString(), adminReadDto.Email, AuthRole.Admin);

            return this.Ok(new LoginAdminSuccessResponse { Token = token, AdminReadDto = adminReadDto });
        }

        [Route("check-auth")]
        [HttpGet]
        public ActionResult<AdminReadDto> CheckAdminAuth()
        {
            var adminReadDto = this._adminService.CheckAdminAuth(this.User.Claims);
            if (adminReadDto == null) return this.Unauthorized();

            return this.Ok(adminReadDto);
        }

        [HttpGet]
        public ActionResult<IEnumerable<AdminReadDto>> GetAllAdmin()
        {
            var adminReadDtos = this._adminService.GetAllAdmin();

            return this.Ok(adminReadDtos);
        }

        [HttpGet("{id}")]
        public ActionResult<AdminReadDto> GetAdminById(int id)
        {
           var adminReadDto = this._adminService.GetAdminById(id);
           if (adminReadDto == null) return this.BadRequest();

            return this.Ok(adminReadDto);
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteAdmin(int id)
        {
            var isDeleted = this._adminService.DeleteAdmin(id);
            if (!isDeleted) return this.BadRequest();

            return this.NoContent();
        }
    }
}
