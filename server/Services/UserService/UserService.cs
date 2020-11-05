using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using AutoMapper;
using server.DataAccess.Repositories.UserRepo;
using server.Dtos.UserDto;
using server.Helpers.CustomResponse;
using server.Helpers.ParameterClass;
using server.Models;
using server.Services.Auth;

namespace server.Services.UserService
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;

        private readonly IAuthManager _authManager;

        private readonly IMapper _mapper;

        public UserService(IUserRepository repository, IAuthManager authManager, IMapper mapper)
        {
            this._repository = repository;
            this._authManager = authManager;
            this._mapper = mapper;
        }

        public UserReadDto AddNewUser(UserCreateDto userCreateDto)
        {
            User existingUser = this._repository.GetUserByEmail(userCreateDto.Email);
            if (existingUser != null) return null;

            var newUserModel = this._mapper.Map<User>(userCreateDto);
            newUserModel.Password = this._authManager.EncryptPassword(newUserModel.Password);

            this._repository.Add(newUserModel);
            this._repository.SaveChanges();

            var userReadDto = this._mapper.Map<UserReadDto>(newUserModel);

            return userReadDto;
        }

        public UserReadDto CheckUserAuth(IEnumerable<Claim> claims)
        {
            var userIdClaim = claims.SingleOrDefault(claim => claim.Type.ToString().Equals("id", StringComparison.InvariantCultureIgnoreCase));
            if (userIdClaim == null) return null;

            int UserId = int.Parse(userIdClaim.Value);

            User currentUser = this._repository.GetById(UserId);
            if (currentUser == null) return null;

            var userReadDto = this._mapper.Map<UserReadDto>(currentUser);

            return userReadDto;
        }

        public bool DeleteUser(int id)
        {
            User user = this._repository.GetById(id);
            if (user == null) return false;

            this._repository.Remove(user);
            this._repository.SaveChanges();

            return true;
        }

        public UserReadDto GetUserById(int id)
        {
            User user = this._repository.GetById(id);

            if (user == null) return null;

            var userReadDto = this._mapper.Map<UserReadDto>(user);

            return userReadDto;
        }

        public UserReadDto LoginUser(LoginParameter loginParameter)
        {
            User existingUser = this._repository.GetUserByEmail(loginParameter.Email);
            if (existingUser == null) return null;

            bool isAuthorized = this._authManager.ComparePassword(loginParameter.Password, existingUser.Password);
            if (!isAuthorized) return null;

            var userReadDto = this._mapper.Map<UserReadDto>(existingUser);

            return userReadDto;
        }

        public bool UpdateUser(int id, UserUpdateDto userUpdateDto)
        {
            User existingUser = this._repository.GetById(id);
            if (existingUser == null) return false;

            this._mapper.Map(userUpdateDto, existingUser);

            this._repository.Update(existingUser);
            this._repository.SaveChanges();

            return true;
        }
    }
}