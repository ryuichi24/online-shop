using Microsoft.AspNetCore.Mvc;
using server.Models;
using server.DataAccess.Repositories.CartItemRepo;
using server.Helpers.ParameterClass;
using System.Collections.Generic;

namespace server.Controllers.CartItemCntlr
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartItemController : ControllerBase, ICartItemController
    {
        private readonly ICartItemRepository _repository;

        public CartItemController(ICartItemRepository repository)
        {
            this._repository = repository;
        }

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

            return this.CreatedAtRoute(new { Id = newCartItem.CartItemId }, newCartItem);
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteCartItem(int id)
        {
            CartItem cartItem = this._repository.GetById(id);
            if (cartItem == null) return NotFound();

            this._repository.Remove(cartItem);
            this._repository.SaveChanges();

            return this.NoContent();
        }


        [HttpGet("all-by-user/{id}")]
        public ActionResult<IEnumerable<CartItem>> GetAllCartItemsByUserId(int id)
        {
            return this.Ok(this._repository.GetAllCartItemsByUserId(id));
        }

        [HttpGet("{id}")]
        public ActionResult<CartItem> GetCartItemById(int id)
        {
            CartItem cartItem = this._repository.GetById(id);

            if (cartItem == null) return NotFound();

            return this.Ok(cartItem);
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