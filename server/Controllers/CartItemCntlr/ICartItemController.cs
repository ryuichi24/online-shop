using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using server.Dtos.CartItemDto;
using server.Helpers.ParameterClass;
using server.Models;

namespace server.Controllers.CartItemCntlr
{
    public interface ICartItemController
    {
        ActionResult<IEnumerable<CartItemReadDto>> GetAllCartItemsByUserId(int id);

        ActionResult<CartItemReadDto> GetCartItemById(int id);

        ActionResult DeleteCartItem(int id);

        ActionResult<CartItemReadDto> AddNewCartItem([FromBody] CartItemCreateDto cartItemCreateDto);

        ActionResult UpdateCartItem(int id, [FromBody] CartItemUpdateDto cartItemUpdateDto);

        ActionResult ClearCartItems(int id);
    }
}