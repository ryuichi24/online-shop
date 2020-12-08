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

        /// <summary>
        /// add a new admin
        /// </summary>
        /// <param name="adminCreateDto"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost]
        public ActionResult<AdminReadDto> AddNewAdmin([FromBody] AdminCreateDto adminCreateDto)
        {
            var adminReadDto = this._adminService.AddNewAdmin(adminCreateDto);
            if (adminReadDto == null) return this.BadRequest();

            return this.CreatedAtRoute(new { Id = adminReadDto.AdminId }, adminReadDto);
        }

        /// <summary>
        /// update an admin
        /// </summary>
        /// <param name="id"></param>
        /// <param name="adminUpdateDto"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public ActionResult UpdateAdmin(int id, [FromBody] AdminUpdateDto adminUpdateDto)
        {
            var isUpdated = this._adminService.UpdateAdmin(id, adminUpdateDto);
            if (!isUpdated) return this.BadRequest();

            return this.NoContent();
        }

        /// <summary>
        /// login an admin
        /// </summary>
        /// <param name="loginParameter"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [Route("login")]
        [HttpPost]
        public ActionResult<LoginAdminSuccessResponse> LoginAdmin(LoginParameter loginParameter)
        {
            var adminReadDto = this._adminService.LoginAdmin(loginParameter);
            if (adminReadDto == null) return this.Unauthorized();

            string token = this._authManager.GenerateJwt(adminReadDto.AdminId.ToString(), adminReadDto.Email, AuthRole.Admin);

            return this.Ok(new LoginAdminSuccessResponse { Token = token, Admin = adminReadDto });
        }

        /// <summary>
        /// check json web token fron the client and authenticate it
        /// </summary>
        /// <returns></returns>
        [Route("check-auth")]
        [HttpGet]
        public ActionResult<AdminReadDto> CheckAdminAuth()
        {
            var adminReadDto = this._adminService.CheckAdminAuth(this.User.Claims);
            if (adminReadDto == null) return this.Unauthorized();

            return this.Ok(adminReadDto);
        }

        /// <summary>
        /// get all admins
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<IEnumerable<AdminReadDto>> GetAllAdmin()
        {
            var adminReadDtos = this._adminService.GetAllAdmin();
            if (adminReadDtos == null) return this.NotFound();

            return this.Ok(adminReadDtos);
        }

        /// <summary>
        /// get an admin by admin Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public ActionResult<AdminReadDto> GetAdminById(int id)
        {
           var adminReadDto = this._adminService.GetAdminById(id);
           if (adminReadDto == null) return this.NotFound();

            return this.Ok(adminReadDto);
        }

        /// <summary>
        /// delete an admin by admin Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public ActionResult DeleteAdmin(int id)
        {
            var isDeleted = this._adminService.DeleteAdmin(id);
            if (!isDeleted) return this.BadRequest();

            return this.NoContent();
        }
    }
}
