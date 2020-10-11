using Microsoft.AspNetCore.Mvc;
using server.Models;
using server.DataAccess.Repositories.CartItemRepo;
using server.Helpers.ParameterClass;

namespace server.Controllers.CartItemCntlr
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartItemController : RootController<CartItem, ICartItemRepository>, ICartItemController
    {
        public CartItemController(ICartItemRepository repository) : base(repository) { }

        public ActionResult<CartItem> AddNewCartItem([FromBody] CartItemCreateParameter cartItemCreateParameter)
        {
            throw new System.NotImplementedException();
        }

        public ActionResult UpdateCartItem(int id, [FromBody] CartItemUpdateParameter cartItemUpdateParameter)
        {
            throw new System.NotImplementedException();
        }
    }
}