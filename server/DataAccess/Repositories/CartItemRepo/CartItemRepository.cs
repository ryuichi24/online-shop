using System.Collections.Generic;
using server.DataAccess;
using server.Models;
using System.Linq;
using System.Data;
using Microsoft.EntityFrameworkCore;

namespace server.DataAccess.Repositories.CartItemRepo
{
    public class CartItemRepository : Repository<CartItem>, ICartItemRepository
    {
        public CartItemRepository(OnlineShopDbContext dbContext) : base(dbContext) { }

        public IEnumerable<CartItem> GetAllCartItemsByUserId(int userId)
        {
            return this._DbContext.Set<CartItem>().Where(c => c.UserId == userId)
            .Include( c => c.Product )
            .Include( c => c.Product.Category )
            .ToList();
        }
    }
}