using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using server.Dtos.AddressDto;

namespace server.Controllers.AddressCntlr
{
    public interface IAddressController
    {
        ActionResult<IEnumerable<AddressReadDto>> GetAllAddressByUserId(int id);

        ActionResult<AddressReadDto> GetAddressById(int id);

        ActionResult DeleteAddress(int id);

        ActionResult<AddressReadDto> AddNewAddress([FromBody] AddressCreateDto addressCreateDto);

        ActionResult UpdateAddress(int id, [FromBody] AddressUpdateDto addressUpdateDto);
    }
}