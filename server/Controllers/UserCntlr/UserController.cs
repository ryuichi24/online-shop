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
using AutoMapper;
using server.Dtos.User;

namespace server.Controllers.UserCntlr
{
    [Authorize(Roles = AuthRole.User)]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase, IUserController
    {
        private readonly IUserRepository _repository;

        private readonly IAuthManager _authManager;

        private readonly IMapper _mapper;

        public UserController(IUserRepository repository, IAuthManager authManager, IMapper mapper)
        {
            this._repository = repository;
            this._authManager = authManager;
            this._mapper = mapper;
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult<SignUpUserSuccessResponse> AddNewUser([FromBody] UserCreateDto userCreateDto)
        {
            User existingUser = this._repository.GetUserByEmail(userCreateDto.Email);
            if (existingUser != null) return this.BadRequest();

            var newUserModel = this._mapper.Map<User>(userCreateDto);
            newUserModel.Password = this._authManager.EncryptPassword(newUserModel.Password);

            this._repository.Add(newUserModel);
            this._repository.SaveChanges();

            string token = this._authManager.GenerateJwt(newUserModel.UserId.ToString(), newUserModel.Email, AuthRole.User);
            return this.CreatedAtRoute(new { Id = newUserModel.UserId }, new SignUpUserSuccessResponse { Token = token, User = newUserModel });
        }


        [HttpPut("{id}")]
        public ActionResult UpdateUser(int id, [FromBody] UserUpdateDto userUpdateDto)
        {
            User existingUser = this._repository.GetById(id);
            if (existingUser == null) return this.NotFound();

            this._mapper.Map(userUpdateDto, existingUser);

            this._repository.Update(existingUser);
            this._repository.SaveChanges();

            return this.NoContent();
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
        public ActionResult<UserReadDto> CheckUserAuth()
        {
            var userIdClaim = this.User.Claims.SingleOrDefault(claim => claim.Type.ToString().Equals("id", StringComparison.InvariantCultureIgnoreCase));
            if (userIdClaim == null) return this.Unauthorized();

            int UserId = int.Parse(userIdClaim.Value);

            User currentUser = this._repository.GetById(UserId);
            if (currentUser == null) return this.Unauthorized();


            return this.Ok(this._mapper.Map<UserReadDto>(currentUser));
        }

        [HttpGet("{id}")]
        public ActionResult<UserReadDto> GetUserById(int id)
        {
            User user = this._repository.GetById(id);

            if (user == null) return NotFound();

            return this.Ok(this._mapper.Map<UserReadDto>(user));
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteUser(int id)
        {
            User user = this._repository.GetById(id);
            if (user == null) return NotFound();

            this._repository.Remove(user);
            this._repository.SaveChanges();

            return this.NoContent();
        }
    }
}