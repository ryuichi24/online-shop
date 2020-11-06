using System.Collections.Generic;
using System.Security.Claims;
using server.Dtos.AdminDto;
using server.Helpers.ParameterClass;

namespace Services.AdminService
{
    public interface IAdminService
    {
        IEnumerable<AdminReadDto> GetAllAdmin();

        AdminReadDto GetAdminById(int id);

        bool DeleteAdmin(int id);

        AdminReadDto AddNewAdmin(AdminCreateDto adminCreateDto);

        bool UpdateAdmin(int id, AdminUpdateDto adminUpdateDto);

        AdminReadDto LoginAdmin(LoginParameter loginParameter);

        AdminReadDto CheckAdminAuth(IEnumerable<Claim> claims);
    }
}