using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using server.Helpers.ParameterClass;
using server.Models;
using server.Repositories.AdminRepo;
using server.Services.Auth;

namespace server.Controllers
{
    [Authorize(Roles = "admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : RootController<Admin, IAdminRepository>
    {
        private readonly IAuthManager _authManager;

        public AdminController(IAdminRepository repository, IAuthManager authManager) : base(repository)
        {
            this._authManager = authManager;
        }

        [HttpPost]
        public override ActionResult<Admin> AddNewEntity([FromBody] Admin newAdmin)
        {
            Admin existingAdmin = this._repository.GetAdminByEmail(newAdmin.Email);
            if(existingAdmin != null) return this.BadRequest();

            newAdmin.Password = this._authManager.EncryptPassword(newAdmin.Password);
            this._repository.Add(newAdmin);
            this._repository.SaveChanges();
            return CreatedAtRoute(new { Id = newAdmin.AdminId }, newAdmin);
        }

        [AllowAnonymous]
        [Route("login")]
        [HttpPost]
        public ActionResult<string> LoginAdmin(LoginParameter loginParameter)
        {
            Admin existingAdmin = this._repository.GetAdminByEmail(loginParameter.Email);
            if(existingAdmin == null) return this.Unauthorized();

            bool isAuthorized = this._authManager.ComparePassword(loginParameter.Password, existingAdmin.Password);
            if(!isAuthorized) return this.Unauthorized();

            string token = this._authManager.GenerateJwt(existingAdmin.AdminId.ToString(), existingAdmin.Email, "admin");

            // TODO: return obj with success msg
            return this.Ok(token);
        }
    }
}
