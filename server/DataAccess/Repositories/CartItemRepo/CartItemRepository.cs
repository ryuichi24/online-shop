using server.DataAccess;
using server.Models;

namespace server.DataAccess.Repositories.CartItemRepo
{
    public class CartItemRepository : Repository<CartItem>, ICartItemRepository
    {
        public CartItemRepository(OnlineShopDbContext dbContext) : base(dbContext) { }
    }
}