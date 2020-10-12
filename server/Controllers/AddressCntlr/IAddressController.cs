using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using server.Helpers.ParameterClass;
using server.Models;

namespace server.Controllers.AddressCntlr
{
    public interface IAddressController
    {
        public ActionResult<IEnumerable<Address>> GetAllAddressByUserId(int id);

        public ActionResult<Address> GetAddressById(int id);

        public ActionResult DeleteAddress(int id);

        public ActionResult<Address> AddNewAddress([FromBody] AddressCreateParameter addressCreateParameter);

        public ActionResult UpdateAddress(int id, [FromBody] AddressUpdateParameter addressUpdateParameter);
    }
}