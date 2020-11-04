using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using server.Dtos.AddressDto;

namespace server.Controllers.AddressCntlr
{
    public interface IAddressController
    {
        public ActionResult<IEnumerable<AddressReadDto>> GetAllAddressByUserId(int id);

        public ActionResult<AddressReadDto> GetAddressById(int id);

        public ActionResult DeleteAddress(int id);

        public ActionResult<AddressReadDto> AddNewAddress([FromBody] AddressCreateDto addressCreateDto);

        public ActionResult UpdateAddress(int id, [FromBody] AddressUpdateDto addressUpdateDto);
    }
}