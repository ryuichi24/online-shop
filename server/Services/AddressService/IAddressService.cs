using System.Collections.Generic;
using server.Dtos.AddressDto;

namespace Services.AddressService
{
    public interface IAddressService
    {
        IEnumerable<AddressReadDto> GetAllAddressByUserId(int id);

        AddressReadDto GetAddressById(int id);

        bool DeleteAddress(int id);

        AddressReadDto AddNewAddress(AddressCreateDto addressCreateDto);

        bool UpdateAddress(int id, AddressUpdateDto addressUpdateDto);
    }
}