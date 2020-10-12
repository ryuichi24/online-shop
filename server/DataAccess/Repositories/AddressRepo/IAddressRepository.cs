using System.Collections.Generic;
using server.Models;

namespace server.DataAccess.Repositories.AddressRepo
{
    public interface IAddressRepository : IRepository<Address>
    {
         // add some features specially for Address
         public IEnumerable<Address> GetAllAddressesByUserId(int userId);
    }
}