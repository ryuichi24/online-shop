using Microsoft.AspNetCore.Mvc;
using server.Helpers.ParameterClass;
using server.Models;

namespace server.Controllers.CartItemCntlr
{
    public interface ICartItemController
    {
        public ActionResult<CartItem> AddNewCartItem([FromBody] CartItemCreateParameter cartItemCreateParameter);

        public ActionResult UpdateCartItem(int id, [FromBody] CartItemUpdateParameter cartItemUpdateParameter);
    }
}