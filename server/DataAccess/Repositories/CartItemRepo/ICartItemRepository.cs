using System.Collections.Generic;
using server.Models;

namespace server.DataAccess.Repositories.CartItemRepo
{
    public interface ICartItemRepository : IRepository<CartItem>
    {
         // add some features specially for CartItem
         IEnumerable<CartItem> GetAllCartItemsByUserId(int userId);

        void ClearCartItems(IEnumerable<CartItem> cartItems);
    }
}