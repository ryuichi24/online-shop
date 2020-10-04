using server.DataAccess;
using server.Models;

namespace server.Repositories.OrderItemRepo
{
    public class OrderItemRepository : Repository<OrderItem>, IOrderItemRepository
    {
        public OrderItemRepository(OnlineShopDbContext dbContext) : base(dbContext) { }
    }
}