using Microsoft.AspNetCore.Mvc;
using server.Helpers.ParameterClass;
using server.Helpers.CustomResponse;
using server.Services.Auth;
using Microsoft.AspNetCore.Authorization;
using server.Helpers;
using server.Dtos.UserDto;
using server.Services.UserService;

namespace server.Controllers.UserCntlr
{
    [Authorize(Roles = AuthRole.User)]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase, IUserController
    {
        private readonly IAuthManager _authManager;

        private readonly IUserService _userService;

        public UserController(IAuthManager authManager, IUserService userService)
        {
            this._authManager = authManager;
            this._userService = userService;
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult<SignUpUserSuccessResponse> AddNewUser([FromBody] UserCreateDto userCreateDto)
        {
            var userReadDto = this._userService.AddNewUser(userCreateDto);
            if (userCreateDto == null) return this.BadRequest();

            string token = this._authManager.GenerateJwt(userReadDto.UserId.ToString(), userReadDto.Email, AuthRole.User);

            return this.CreatedAtRoute(new { Id = userReadDto.UserId }, new SignUpUserSuccessResponse { Token = token, User = userReadDto });
        }

        [HttpPut("{id}")]
        public ActionResult UpdateUser(int id, [FromBody] UserUpdateDto userUpdateDto)
        {
            var isUpdated = this._userService.UpdateUser(id ,userUpdateDto);
            if (!isUpdated) this.BadRequest();

            return this.NoContent();
        }

        [AllowAnonymous]
        [Route("login")]
        [HttpPost]
        public ActionResult<LoginUserSuccessResponse> LoginUser(LoginParameter loginParameter)
        {
            var userReadDto = this._userService.LoginUser(loginParameter);
            if(userReadDto == null) return this.Unauthorized();

            string token = this._authManager.GenerateJwt(userReadDto.UserId.ToString(), userReadDto.Email, AuthRole.User);

            return this.Ok(new LoginUserSuccessResponse { Token = token, User = userReadDto });
        }

        [Route("check-auth")]
        [HttpGet]
        public ActionResult<UserReadDto> CheckUserAuth()
        {
            var userReadDto = this._userService.CheckUserAuth(this.User.Claims);
            if(userReadDto == null) return this.Unauthorized();

            return this.Ok(userReadDto);
        }

        [HttpGet("{id}")]
        public ActionResult<UserReadDto> GetUserById(int id)
        {
            var userReadDto = this._userService.GetUserById(id);
            if(userReadDto == null) return this.NotFound();

            return this.Ok(userReadDto);
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteUser(int id)
        {
            var isDeleted = this._userService.DeleteUser(id);
            if (!isDeleted) return this.BadRequest();

            return this.NoContent();
        }
    }
}