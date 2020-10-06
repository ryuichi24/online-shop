using server.DataAccess;
using server.Models;

namespace server.DataAccess.Repositories.OrderRepo
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        public OrderRepository(OnlineShopDbContext dbContext) : base(dbContext) {}
    }
}