using server.DataAccess;
using server.Models;

namespace server.DataAccess.Repositories.AddressRepo
{
    public class AddressRepository : Repository<Address>, IAddressRepository
    {
        public AddressRepository(OnlineShopDbContext dbContext) : base(dbContext) {}
    }
}