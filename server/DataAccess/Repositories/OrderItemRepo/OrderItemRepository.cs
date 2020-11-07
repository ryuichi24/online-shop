using System.Collections.Generic;
using server.DataAccess;
using server.Models;

namespace server.DataAccess.Repositories.OrderItemRepo
{
    public class OrderItemRepository : Repository<OrderItem>, IOrderItemRepository
    {
        public OrderItemRepository(OnlineShopDbContext dbContext) : base(dbContext) { }

        public void AddOrderItems(IEnumerable<OrderItem> orderItems)
        {
            this._DbContext.Set<OrderItem>().AddRange(orderItems);
        }
    }
}