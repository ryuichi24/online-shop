using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using AutoMapper;
using server.DataAccess.Repositories.AdminRepo;
using server.Dtos.AdminDto;
using server.Helpers.ParameterClass;
using server.Models;
using server.Services.Auth;

namespace Services.AdminService
{
    public class AdminService : IAdminService
    {
        private readonly IAdminRepository _repository;

        private readonly IAuthManager _authManager;

        public readonly IMapper _mapper;

        public AdminService(IAdminRepository repository, IAuthManager authManager, IMapper mapper)
        {
            this._repository = repository;
            this._authManager = authManager;
            this._mapper = mapper;
        }

        public AdminReadDto AddNewAdmin(AdminCreateDto adminCreateDto)
        {
            Admin existingAdmin = this._repository.GetAdminByEmail(adminCreateDto.Email);
            if (existingAdmin != null) return null;

            var newAdminModel = this._mapper.Map<Admin>(adminCreateDto);
            newAdminModel.Password = this._authManager.EncryptPassword(newAdminModel.Password);

            this._repository.Add(newAdminModel);
            this._repository.SaveChanges();

            var adminReadDto = this._mapper.Map<AdminReadDto>(newAdminModel);

            return adminReadDto;
        }

        public AdminReadDto CheckAdminAuth(IEnumerable<Claim> claims)
        {
            var adminIdClaim = claims.SingleOrDefault(claim => claim.Type.ToString().Equals("id", StringComparison.InvariantCultureIgnoreCase));
            if (adminIdClaim == null) return null;

            int adminId = int.Parse(adminIdClaim.Value);

            Admin currentAdmin = this._repository.GetById(adminId);
            if(currentAdmin == null) return null;

            var adminReadDto = this._mapper.Map<AdminReadDto>(currentAdmin);

            return adminReadDto;
        }

        public bool DeleteAdmin(int id)
        {
            Admin admin = this._repository.GetById(id);
            if (admin == null) return false;

            this._repository.Remove(admin);
            this._repository.SaveChanges();

            return true;
        }

        public AdminReadDto GetAdminById(int id)
        {
            Admin admin = this._repository.GetById(id);

            if (admin == null) return null;

            var adminReadDto = this._mapper.Map<AdminReadDto>(admin);

            return adminReadDto;
        }

        public IEnumerable<AdminReadDto> GetAllAdmin()
        {
            var admins = this._repository.GetAll();
            var adminReadDtos = this._mapper.Map<IEnumerable<AdminReadDto>>(admins);

            return adminReadDtos;
        }

        public AdminReadDto LoginAdmin(LoginParameter loginParameter)
        {
            Admin existingAdmin = this._repository.GetAdminByEmail(loginParameter.Email);
            if (existingAdmin == null) return null;

            bool isAuthorized = this._authManager.ComparePassword(loginParameter.Password, existingAdmin.Password);
            if (!isAuthorized) return null;

            var adminReadDto = this._mapper.Map<AdminReadDto>(existingAdmin);

            return adminReadDto;
        }

        public bool UpdateAdmin(int id, AdminUpdateDto adminUpdateDto)
        {
            Admin existingAdmin = this._repository.GetById(id);
            if (existingAdmin == null) return false;

            this._mapper.Map(adminUpdateDto, existingAdmin);

            this._repository.Update(existingAdmin);
            this._repository.SaveChanges();

            return true;
        }
    }
}