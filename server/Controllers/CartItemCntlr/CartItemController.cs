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

        [HttpPost]
        public ActionResult<CartItem> AddNewCartItem([FromBody] CartItemCreateParameter cartItemCreateParameter)
        {
            CartItem newCartItem = new CartItem()
            {
                ProductId = cartItemCreateParameter.ProductId,
                UserId = cartItemCreateParameter.UserId,
                CartItemCount = cartItemCreateParameter.CartItemCount
            };

            this._repository.Add(newCartItem);
            this._repository.SaveChanges();

            return this.CreatedAtRoute(new { Id = newCartItem.CardItemId }, newCartItem);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateCartItem(int id, [FromBody] CartItemUpdateParameter cartItemUpdateParameter)
        {
            CartItem existingCartItem = this._repository.GetById(id);
            if (existingCartItem == null) return this.NotFound();

            if (!cartItemUpdateParameter.CartItemCount.Equals(null)) existingCartItem.CartItemCount = cartItemUpdateParameter.CartItemCount;

            this._repository.Update(existingCartItem);
            this._repository.SaveChanges();

            return this.NoContent();
        }
    }
}