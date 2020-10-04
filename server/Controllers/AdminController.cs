using Microsoft.AspNetCore.Mvc;
using server.Models;
using server.Repositories.AdminRepo;
using server.Services.Auth;

namespace server.Controllers
{
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
            // TODO: check if the user is already created by his/her email
            Admin existingAdmin = this._repository.GetAdminByEmail(newAdmin.Email);
            if(existingAdmin != null) return this.BadRequest();

            newAdmin.Password = this._authManager.EncryptPassword(newAdmin.Password);
            this._repository.Add(newAdmin);
            this._repository.SaveChanges();
            return CreatedAtRoute(new { Id = newAdmin.AdminId }, newAdmin);
        }
    }
}