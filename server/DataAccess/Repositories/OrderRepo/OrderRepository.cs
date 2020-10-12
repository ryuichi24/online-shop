using System.Collections.Generic;
using server.DataAccess;
using server.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace server.DataAccess.Repositories.OrderRepo
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        public OrderRepository(OnlineShopDbContext dbContext) : base(dbContext) {}

        public IEnumerable<Order> GetAllOrdersByUserId(int userId)
        {
            return this._DbContext.Set<Order>().Where(o => o.UserId == userId)
            .Include(o => o.Address)
            .Include(o => o.OrderItems).ThenInclude( i => i.Product )
            .ToList();
        }
    }
}