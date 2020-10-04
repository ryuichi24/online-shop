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
        public override ActionResult<Admin> AddNewEntity([FromBody] Admin entity)
        {
            // TODO: check if the user is already created by his/her email

            entity.Password = this._authManager.EncryptPassword(entity.Password);
            base._repository.Add(entity);
            base._repository.SaveChanges();
            return CreatedAtRoute(new { Id = entity.AdminId }, entity);
        }
    }
}