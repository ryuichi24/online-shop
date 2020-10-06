using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using server.Helpers;
using server.Helpers.CustomResponse;
using server.Helpers.ParameterClass;
using server.Models;
using server.DataAccess.Repositories.AdminRepo;
using server.Services.Auth;
using System;

namespace server.Controllers.AdminCntlr
{
    [Authorize(Roles = AuthRole.Admin)]
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : RootController<Admin, IAdminRepository>, IAdminController
    {
        private readonly IAuthManager _authManager;

        public AdminController(IAdminRepository repository, IAuthManager authManager) : base(repository)
        {
            this._authManager = authManager;
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult<Admin> AddNewAdmin([FromBody] AdminCreateParameter adminCreateParameter)
        {
            Admin existingAdmin = this._repository.GetAdminByEmail(adminCreateParameter.Email);
            if (existingAdmin != null) return this.BadRequest();

            Admin newAdmin = new Admin()
            {
                Name = adminCreateParameter.Name,
                Email = adminCreateParameter.Email,
                Phone = adminCreateParameter.Phone,
                Password = this._authManager.EncryptPassword(adminCreateParameter.Password)
            };

            this._repository.Add(newAdmin);
            this._repository.SaveChanges();
            return this.CreatedAtRoute(new { Id = newAdmin.AdminId }, newAdmin);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateAdmin(int id, [FromBody] AdminUpdateParameter adminUpdateParameter)
        {
            Admin existingAdmin = this._repository.GetById(id);
            if (existingAdmin == null) return this.NotFound();

            if (adminUpdateParameter.Name != null) existingAdmin.Name = adminUpdateParameter.Name;
            if (adminUpdateParameter.Email != null) existingAdmin.Email = adminUpdateParameter.Email;
            if (adminUpdateParameter.Phone != null) existingAdmin.Phone = adminUpdateParameter.Phone;
            if (adminUpdateParameter.Password != null) existingAdmin.Password = this._authManager.EncryptPassword(adminUpdateParameter.Password);

            this._repository.Update(existingAdmin);
            this._repository.SaveChanges();

            return NoContent();
        }

        [AllowAnonymous]
        [Route("login")]
        [HttpPost]
        public ActionResult<LoginAdminSuccessResponse> LoginAdmin(LoginParameter loginParameter)
        {
            Admin existingAdmin = this._repository.GetAdminByEmail(loginParameter.Email);
            if (existingAdmin == null) return this.Unauthorized();

            bool isAuthorized = this._authManager.ComparePassword(loginParameter.Password, existingAdmin.Password);
            if (!isAuthorized) return this.Unauthorized();

            string token = this._authManager.GenerateJwt(existingAdmin.AdminId.ToString(), existingAdmin.Email, AuthRole.Admin);

            return this.Ok(new LoginAdminSuccessResponse { Token = token, Admin = existingAdmin });
        }

        [AllowAnonymous]
        [Route("check-auth")]
        [HttpGet]
        public ActionResult<Admin> CheckAdminAuth()
        {
            var adminIdClaim = this.User.Claims.SingleOrDefault(claim => claim.Type.ToString().Equals("id", StringComparison.InvariantCultureIgnoreCase));
            if (adminIdClaim == null) return this.Unauthorized();

            int adminId = int.Parse(adminIdClaim.Value);

            Admin currentAdmin = this._repository.GetById(adminId);
            if(currentAdmin == null) return this.Unauthorized();

            return this.Ok(currentAdmin);
        }
    }
}
