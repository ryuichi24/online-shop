using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using server.Dtos.CartItemDto;
using server.Helpers.ParameterClass;
using server.Models;

namespace server.Controllers.CartItemCntlr
{
    public interface ICartItemController
    {
        public ActionResult<IEnumerable<CartItemReadDto>> GetAllCartItemsByUserId(int id);

        public ActionResult<CartItemReadDto> GetCartItemById(int id);

        public ActionResult DeleteCartItem(int id);

        public ActionResult<CartItemReadDto> AddNewCartItem([FromBody] CartItemCreateDto cartItemCreateDto);

        public ActionResult UpdateCartItem(int id, [FromBody] CartItemUpdateDto cartItemUpdateDto);

        public ActionResult ClearCartItems(int id);
    }
}