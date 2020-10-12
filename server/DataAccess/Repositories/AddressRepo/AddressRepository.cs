using System.Collections.Generic;
using System.Linq;
using server.Models;

namespace server.DataAccess.Repositories.AddressRepo
{
    public class AddressRepository : Repository<Address>, IAddressRepository
    {
        public AddressRepository(OnlineShopDbContext dbContext) : base(dbContext) {}

        public IEnumerable<Address> GetAllAddressesByUserId(int userId)
        {
            return this._DbContext.Set<Address>()
            .Where(a => a.UserId == userId)
            .ToList();
        }
    }
}