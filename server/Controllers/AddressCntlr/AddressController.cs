using Microsoft.AspNetCore.Mvc;
using server.Models;
using server.DataAccess.Repositories.AddressRepo;
using server.Helpers.ParameterClass;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using server.Helpers;

namespace server.Controllers.AddressCntlr
{
    [Authorize(Roles = AuthRole.User)]
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase, IAddressController
    {
        private readonly IAddressRepository _repository;

        public AddressController(IAddressRepository repository)
        {
            this._repository = repository;
        }

        [HttpPost]
        public ActionResult<Address> AddNewAddress([FromBody] AddressCreateParameter addressCreateParameter)
        {
            Address newAddress = new Address()
            {
                Address1 = addressCreateParameter.Address1,
                Address2 = addressCreateParameter.Address2,
                City = addressCreateParameter.City,
                PostCode = addressCreateParameter.PostCode,
                UserId = addressCreateParameter.UserId,
            };

            this._repository.Add(newAddress);
            this._repository.SaveChanges();

            return this.CreatedAtRoute(new { Id = newAddress.AddressId }, newAddress);
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
        public ActionResult<Address> GetAddressById(int id)
        {
            Address address = this._repository.GetById(id);
            if (address == null) this.NotFound();

            return this.Ok(address);
        }

        [HttpGet("all-by-user/{id}")]
        public ActionResult<IEnumerable<Address>> GetAllAddressByUserId(int id)
        {
            return this.Ok(this._repository.GetAllAddressesByUserId(id));
        }

        [HttpPut("{id}")]
        public ActionResult UpdateAddress(int id, [FromBody] AddressUpdateParameter addressUpdateParameter)
        {
            Address existingAddress = this._repository.GetById(id);
            if (existingAddress == null) return this.NotFound();

            if (addressUpdateParameter.Address1 != null) existingAddress.Address1 = addressUpdateParameter.Address1;
            if (addressUpdateParameter.Address2 != null) existingAddress.Address2 = addressUpdateParameter.Address2;
            if (addressUpdateParameter.City != null) existingAddress.City = addressUpdateParameter.City;
            if (addressUpdateParameter.PostCode != null) existingAddress.PostCode = addressUpdateParameter.PostCode;

            this._repository.Update(existingAddress);
            this._repository.SaveChanges();

            return this.NoContent();
        }
    }
}