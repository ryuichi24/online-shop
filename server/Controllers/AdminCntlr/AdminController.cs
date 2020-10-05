using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using server.Helpers;
using server.Helpers.ParameterClass;
using server.Models;
using server.Repositories.AdminRepo;
using server.Services.Auth;

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

        [HttpPost]
        public ActionResult<Admin> AddNewEntity([FromBody] AdminParameter adminParameter)
        {
            Admin existingAdmin = this._repository.GetAdminByEmail(adminParameter.Email);
            if(existingAdmin != null) return this.BadRequest();

            Admin newAdmin = new Admin()
            {
                Name = adminParameter.Name,
                Email = adminParameter.Email,
                Phone = adminParameter.Phone,
                Password = this._authManager.EncryptPassword(adminParameter.Password)
            };

            this._repository.Add(newAdmin);
            this._repository.SaveChanges();
            return CreatedAtRoute(new { Id = newAdmin.AdminId }, newAdmin);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateEntity(int id, [FromBody] AdminParameter entityToUpdate)
        {
            Admin existingAdmin = this._repository.GetById(id);
            if (existingAdmin == null) return this.NotFound();

            if(entityToUpdate.Name != null) existingAdmin.Name = entityToUpdate.Name;
            if(entityToUpdate.Email != null) existingAdmin.Email = entityToUpdate.Email;
            if(entityToUpdate.Phone != null) existingAdmin.Phone = entityToUpdate.Phone;
            if(entityToUpdate.Password != null) existingAdmin.Password = this._authManager.EncryptPassword(entityToUpdate.Password);

            this._repository.Update(existingAdmin);
            this._repository.SaveChanges();

            return NoContent();
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

            string token = this._authManager.GenerateJwt(existingAdmin.AdminId.ToString(), existingAdmin.Email, AuthRole.Admin);

            // TODO: return obj with success msg
            return this.Ok(token);
        }

    }
}
