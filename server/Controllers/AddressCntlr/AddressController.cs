using Microsoft.AspNetCore.Mvc;
using server.DataAccess.Repositories.AddressRepo;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using server.Helpers;
using AutoMapper;
using server.Dtos.AddressDto;
using Services.AddressService;

namespace server.Controllers.AddressCntlr
{
    [Authorize(Roles = AuthRole.User)]
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase, IAddressController
    {
        private readonly IAddressService _addressService;

        public AddressController(IAddressRepository repository, IMapper mapper, IAddressService addressService)
        {
            this._addressService = addressService;
        }

        [HttpPost]
        public ActionResult<AddressReadDto> AddNewAddress([FromBody] AddressCreateDto addressCreateDto)
        {
            var addressReadDto = this._addressService.AddNewAddress(addressCreateDto);
            if (addressReadDto == null) return this.BadRequest();

            return this.CreatedAtRoute(new { Id = addressReadDto.AddressId }, addressReadDto);
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteAddress(int id)
        {
            var isDeleted = this._addressService.DeleteAddress(id);
            if(!isDeleted) return this.BadRequest();

            return this.NoContent();
        }

        [HttpGet("{id}")]
        public ActionResult<AddressReadDto> GetAddressById(int id)
        {
            var addressReadDto = this._addressService.GetAddressById(id);
            if (addressReadDto == null) return this.BadRequest();

            return this.Ok(addressReadDto);
        }

        [HttpGet("all-by-user/{id}")]
        public ActionResult<IEnumerable<AddressReadDto>> GetAllAddressByUserId(int id)
        {
            var addressReadDtos = this._addressService.GetAllAddressByUserId(id);
            if (addressReadDtos == null) return this.BadRequest();

            return this.Ok(addressReadDtos);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateAddress(int id, [FromBody] AddressUpdateDto addressUpdateDto)
        {
            var isUpdated = this._addressService.UpdateAddress(id, addressUpdateDto);
            if (!isUpdated) return this.BadRequest();

            return this.NoContent();
        }
    }
}