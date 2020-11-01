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
using System.Collections.Generic;
using AutoMapper;
using server.Dtos.Admin;

namespace server.Controllers.AdminCntlr
{
    [Authorize(Roles = AuthRole.Admin)]
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase, IAdminController
    {
        private readonly IAdminRepository _repository;

        private readonly IAuthManager _authManager;

        public readonly IMapper _mapper;

        public AdminController(IAdminRepository repository, IAuthManager authManager, IMapper mapper)
        {
            this._repository = repository;
            this._authManager = authManager;
            this._mapper = mapper;
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult<AdminReadDto> AddNewAdmin([FromBody] AdminCreateDto adminCreateDto)
        {
            Admin existingAdmin = this._repository.GetAdminByEmail(adminCreateDto.Email);
            if (existingAdmin != null) return this.BadRequest();

            var newAdminModel = this._mapper.Map<Admin>(adminCreateDto);
            newAdminModel.Password = this._authManager.EncryptPassword(newAdminModel.Password);

            this._repository.Add(newAdminModel);
            this._repository.SaveChanges();
            return this.CreatedAtRoute(new { Id = newAdminModel.AdminId }, this._mapper.Map<AdminReadDto>(newAdminModel));
        }

        [HttpPut("{id}")]
        public ActionResult UpdateAdmin(int id, [FromBody] AdminUpdateDto adminUpdateDto)
        {
            Admin existingAdmin = this._repository.GetById(id);
            if (existingAdmin == null) return this.NotFound();

            this._mapper.Map(adminUpdateDto, existingAdmin);

            this._repository.Update(existingAdmin);
            this._repository.SaveChanges();

            return this.NoContent();
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

        [Route("check-auth")]
        [HttpGet]
        public ActionResult<AdminReadDto> CheckAdminAuth()
        {
            var adminIdClaim = this.User.Claims.SingleOrDefault(claim => claim.Type.ToString().Equals("id", StringComparison.InvariantCultureIgnoreCase));
            if (adminIdClaim == null) return this.Unauthorized();

            int adminId = int.Parse(adminIdClaim.Value);

            Admin currentAdmin = this._repository.GetById(adminId);
            if(currentAdmin == null) return this.Unauthorized();

            return this.Ok(this._mapper.Map<AdminReadDto>(currentAdmin));
        }

        [HttpGet]
        public ActionResult<IEnumerable<AdminReadDto>> GetAllAdmin()
        {
            return this.Ok(this._mapper.Map<IEnumerable<AdminReadDto>>(this._repository.GetAll()));
        }

        [HttpGet("{id}")]
        public ActionResult<AdminReadDto> GetAdminById(int id)
        {
           Admin admin = this._repository.GetById(id);

            if (admin == null) return NotFound();

            return this.Ok(this._mapper.Map<AdminReadDto>(admin));
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteAdmin(int id)
        {
            Admin admin = this._repository.GetById(id);
            if (admin == null) return NotFound();

            this._repository.Remove(admin);
            this._repository.SaveChanges();

            return this.NoContent();
        }
    }
}
