using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using server.Helpers;
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

        public AddressController(IAddressService addressService)
        {
            this._addressService = addressService;
        }

        /// <summary>
        /// add a new address in the database
        /// </summary>
        /// <param name="addressCreateDto"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult<AddressReadDto> AddNewAddress([FromBody] AddressCreateDto addressCreateDto)
        {
            var addressReadDto = this._addressService.AddNewAddress(addressCreateDto);
            if (addressReadDto == null) return this.BadRequest();

            return this.CreatedAtRoute(new { Id = addressReadDto.AddressId }, addressReadDto);
        }

        /// <summary>
        /// delete an address by an address Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public ActionResult DeleteAddress(int id)
        {
            var isDeleted = this._addressService.DeleteAddress(id);
            if(!isDeleted) return this.BadRequest();

            return this.NoContent();
        }

        /// <summary>
        /// get an address by an address Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public ActionResult<AddressReadDto> GetAddressById(int id)
        {
            var addressReadDto = this._addressService.GetAddressById(id);
            if (addressReadDto == null) return this.NotFound();

            return this.Ok(addressReadDto);
        }

        /// <summary>
        /// get all addresses by user Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("all-by-user/{id}")]
        public ActionResult<IEnumerable<AddressReadDto>> GetAllAddressByUserId(int id)
        {
            var addressReadDtos = this._addressService.GetAllAddressByUserId(id);
            if (addressReadDtos == null) return this.NotFound();

            return this.Ok(addressReadDtos);
        }

        /// <summary>
        /// update an address
        /// </summary>
        /// <param name="id"></param>
        /// <param name="addressUpdateDto"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public ActionResult UpdateAddress(int id, [FromBody] AddressUpdateDto addressUpdateDto)
        {
            var isUpdated = this._addressService.UpdateAddress(id, addressUpdateDto);
            if (!isUpdated) return this.BadRequest();

            return this.NoContent();
        }
    }
}