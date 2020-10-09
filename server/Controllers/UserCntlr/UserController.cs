using Microsoft.AspNetCore.Mvc;
using server.Models;
using server.DataAccess.Repositories.UserRepo;
using server.Helpers.ParameterClass;
using server.Helpers.CustomResponse;
using server.Services.Auth;
using Microsoft.AspNetCore.Authorization;
using server.Helpers;
using System.Linq;
using System;

namespace server.Controllers.UserCntlr
{
    [Authorize(Roles = AuthRole.User)]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : RootController<User, IUserRepository>, IUserController
    {
        private readonly IAuthManager _authManager;

        public UserController(IUserRepository repository, IAuthManager authManager) : base(repository)
        {
            this._authManager = authManager;
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult<SignUpUserSuccessResponse> AddNewUser([FromBody] UserCreateParameter userCreateParameter)
        {
            User existingUser = this._repository.GetUserByEmail(userCreateParameter.Email);
            if (existingUser != null) return this.BadRequest();

            User newUser = new User()
            {
                FirstName = userCreateParameter.FirstName,
                LastName = userCreateParameter.LastName,
                Email = userCreateParameter.Email,
                Password = this._authManager.EncryptPassword(userCreateParameter.Password),
                Phone = userCreateParameter.Phone
            };

            this._repository.Add(newUser);
            this._repository.SaveChanges();

            string token = this._authManager.GenerateJwt(newUser.UserId.ToString(), newUser.Email, AuthRole.User);
            return this.CreatedAtRoute(new { Id = newUser.UserId }, new SignUpUserSuccessResponse { Token = token, User = newUser });
        }


        [HttpPut("{id}")]
        public ActionResult<User> UpdateUser(int id, [FromBody] UserUpdateParameter userUpdateParameter)
        {
            User existingUser = this._repository.GetById(id);
            if (existingUser == null) return this.NotFound();

            if (userUpdateParameter.FirstName != null) existingUser.FirstName = userUpdateParameter.FirstName;
            if (userUpdateParameter.LastName != null) existingUser.LastName = userUpdateParameter.LastName;
            if (userUpdateParameter.Email != null) existingUser.Email = userUpdateParameter.Email;
            if (userUpdateParameter.Phone != null) existingUser.Phone = userUpdateParameter.Phone;
            if (userUpdateParameter.Password != null) existingUser.Password = this._authManager.EncryptPassword(userUpdateParameter.Password);

            this._repository.Update(existingUser);
            this._repository.SaveChanges();

            return this.Ok(existingUser);
        }

        [AllowAnonymous]
        [Route("login")]
        [HttpPost]
        public ActionResult<LoginUserSuccessResponse> LoginUser(LoginParameter loginParameter)
        {
            User existingUser = this._repository.GetUserByEmail(loginParameter.Email);
            if (existingUser == null) return this.Unauthorized();

            bool isAuthorized = this._authManager.ComparePassword(loginParameter.Password, existingUser.Password);
            if (!isAuthorized) return this.Unauthorized();

            string token = this._authManager.GenerateJwt(existingUser.UserId.ToString(), existingUser.Email, AuthRole.User);

            return this.Ok(new LoginUserSuccessResponse { Token = token, User = existingUser });
        }

        [Route("check-auth")]
        [HttpGet]
        public ActionResult<User> CheckUserAuth()
        {
            var userIdClaim = this.User.Claims.SingleOrDefault(claim => claim.Type.ToString().Equals("id", StringComparison.InvariantCultureIgnoreCase));
            if (userIdClaim == null) return this.Unauthorized();

            int UserId = int.Parse(userIdClaim.Value);

            User currentUser = this._repository.GetById(UserId);
            if (currentUser == null) return this.Unauthorized();

            return this.Ok(currentUser);
        }
    }
}