using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using server.Helpers.ParameterClass;
using server.Models;

namespace server.Controllers.CartItemCntlr
{
    public interface ICartItemController
    {
        public ActionResult<IEnumerable<CartItem>> GetAllCartItems();

        public ActionResult<CartItem> GetCartItemById(int id);

        public ActionResult DeleteCartItem(int id);

        public ActionResult<CartItem> AddNewCartItem([FromBody] CartItemCreateParameter cartItemCreateParameter);

        public ActionResult UpdateCartItem(int id, [FromBody] CartItemUpdateParameter cartItemUpdateParameter);
    }
}