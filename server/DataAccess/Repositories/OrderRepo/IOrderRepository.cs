using System.Collections.Generic;
using server.Models;

namespace server.DataAccess.Repositories.OrderRepo
{
    public interface IOrderRepository : IRepository<Order>
    {
        // add some features specially for Order
        IEnumerable<Order> GetAllOrderWithPopulatedChildren();

        IEnumerable<Order> GetAllOrdersByUserId(int userId);
    }
}