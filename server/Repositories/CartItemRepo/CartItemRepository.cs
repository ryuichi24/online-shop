using server.DataAccess;
using server.Models;

namespace server.Repositories.CartItemRepo
{
    public class CartItemRepository : Repository<CartItem>, ICartItemRepository
    {
        public CartItemRepository(OnlineShopDbContext dbContext) : base(dbContext) { }
    }
}