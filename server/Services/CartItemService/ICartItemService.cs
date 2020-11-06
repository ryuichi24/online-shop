using System.Collections.Generic;
using server.Dtos.CartItemDto;

namespace Services.CartItemService
{
    public interface ICartItemService
    {
        IEnumerable<CartItemReadDto> GetAllCartItemsByUserId(int id);

        CartItemReadDto GetCartItemById(int id);

        bool DeleteCartItem(int id);

        CartItemReadDto AddNewCartItem(CartItemCreateDto cartItemCreateDto);

        bool UpdateCartItem(int id, CartItemUpdateDto cartItemUpdateDto);

        bool ClearCartItems(int id);
    }
}