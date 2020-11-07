using System.Collections.Generic;
using server.Models;

namespace server.DataAccess.Repositories.OrderItemRepo
{
    public interface IOrderItemRepository : IRepository<OrderItem>
    {
        // add some features specially for OrderItem
        void AddOrderItems(IEnumerable<OrderItem> orderItems);
    }
}