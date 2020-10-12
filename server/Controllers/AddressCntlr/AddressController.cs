using Microsoft.AspNetCore.Mvc;
using server.Models;
using server.DataAccess.Repositories.AddressRepo;
using server.Helpers.ParameterClass;
using System.Collections.Generic;

namespace server.Controllers.AddressCntlr
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase, IAddressController
    {
        private readonly IAddressRepository _repository;

        public AddressController(IAddressRepository repository)
        {
            this._repository = repository;
        }

        public ActionResult<Address> AddNewAddress([FromBody] AddressCreateParameter addressCreateParameter)
        {
            throw new System.NotImplementedException();
        }

        public ActionResult DeleteAddress(int id)
        {
            throw new System.NotImplementedException();
        }

        public ActionResult<Address> GetAddressById(int id)
        {
            throw new System.NotImplementedException();
        }

        public ActionResult<IEnumerable<Address>> GetAllAddressByUserId(int id)
        {
            throw new System.NotImplementedException();
        }

        public ActionResult UpdateAddress(int id, [FromBody] AddressUpdateParameter addressUpdateParameter)
        {
            throw new System.NotImplementedException();
        }
    }
}