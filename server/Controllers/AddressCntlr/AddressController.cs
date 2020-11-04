using Microsoft.AspNetCore.Mvc;
using server.Models;
using server.DataAccess.Repositories.AddressRepo;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using server.Helpers;
using AutoMapper;
using server.Dtos.AddressDto;

namespace server.Controllers.AddressCntlr
{
    [Authorize(Roles = AuthRole.User)]
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase, IAddressController
    {
        private readonly IAddressRepository _repository;
        private readonly IMapper _mapper;

        public AddressController(IAddressRepository repository, IMapper mapper)
        {
            this._repository = repository;
            this._mapper = mapper;
        }

        [HttpPost]
        public ActionResult<AddressReadDto> AddNewAddress([FromBody] AddressCreateDto addressCreateDto)
        {
            var newAddressModel = this._mapper.Map<Address>(addressCreateDto);

            this._repository.Add(newAddressModel);
            this._repository.SaveChanges();

            return this.CreatedAtRoute(new { Id = newAddressModel.AddressId }, newAddressModel);
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteAddress(int id)
        {
            Address existingAddress = this._repository.GetById(id);
            if (existingAddress == null) this.NotFound();

            try
            {
                this._repository.Remove(existingAddress);
                this._repository.SaveChanges();
                return this.NoContent();
            }
            catch (System.Exception)
            {
                return this.Forbid();
            }
        }

        [HttpGet("{id}")]
        public ActionResult<AddressReadDto> GetAddressById(int id)
        {
            Address address = this._repository.GetById(id);
            if (address == null) this.NotFound();

            return this.Ok(this._mapper.Map<AddressReadDto>(address));
        }

        [HttpGet("all-by-user/{id}")]
        public ActionResult<IEnumerable<AddressReadDto>> GetAllAddressByUserId(int id)
        {
            return this.Ok(this._mapper.Map<IEnumerable<AddressReadDto>>(this._repository.GetAllAddressesByUserId(id)));
        }

        [HttpPut("{id}")]
        public ActionResult UpdateAddress(int id, [FromBody] AddressUpdateDto addressUpdateDto)
        {
            Address existingAddress = this._repository.GetById(id);
            if (existingAddress == null) return this.NotFound();

            this._mapper.Map(addressUpdateDto, existingAddress);

            this._repository.Update(existingAddress);
            this._repository.SaveChanges();

            return this.NoContent();
        }
    }
}