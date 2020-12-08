using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using server.Helpers;
using server.Dtos.CartItemDto;
using Services.CartItemService;

namespace server.Controllers.CartItemCntlr
{
    [Authorize(Roles = AuthRole.User)]
    [Route("api/[controller]")]
    [ApiController]
    public class CartItemController : ControllerBase, ICartItemController
    {
        private readonly ICartItemService _cartItemService;

        public CartItemController(ICartItemService cartItemService)
        {
            this._cartItemService = cartItemService;
        }

        /// <summary>
        /// add a new cart item
        /// </summary>
        /// <param name="cartItemCreateDto"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult<CartItemReadDto> AddNewCartItem([FromBody] CartItemCreateDto cartItemCreateDto)
        {
            var cartItemReadDto = this._cartItemService.AddNewCartItem(cartItemCreateDto);
            if (cartItemReadDto == null) return this.BadRequest();

            return this.CreatedAtRoute(new { Id = cartItemReadDto.CartItemId }, cartItemReadDto);
        }

        /// <summary>
        /// delete a cart item
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public ActionResult DeleteCartItem(int id)
        {
            var isDeleted = this._cartItemService.DeleteCartItem(id);
            if (!isDeleted) return this.BadRequest();

            return this.NoContent();
        }

        /// <summary>
        /// get all cart items by user Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("all-by-user/{id}")]
        public ActionResult<IEnumerable<CartItemReadDto>> GetAllCartItemsByUserId(int id)
        {
            var cartItemReadDtos = this._cartItemService.GetAllCartItemsByUserId(id);
            if (cartItemReadDtos == null) return this.NotFound();

            return this.Ok(cartItemReadDtos);
        }

        /// <summary>
        /// get a cart item by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public ActionResult<CartItemReadDto> GetCartItemById(int id)
        {
            var cartItemReadDto = this._cartItemService.GetCartItemById(id);
            if (cartItemReadDto == null) return this.NotFound();

            return this.Ok(cartItemReadDto);
        }

        /// <summary>
        /// update a cart item
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cartItemUpdateDto"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public ActionResult UpdateCartItem(int id, [FromBody] CartItemUpdateDto cartItemUpdateDto)
        {
            var isUpdated = this._cartItemService.UpdateCartItem(id, cartItemUpdateDto);
            if (!isUpdated) return this.BadRequest();

            return this.NoContent();
        }

        /// <summary>
        /// delete all cart items by user Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("clear-cart-items/{id}")]
        public ActionResult ClearCartItems(int id)
        {
            var isDeleted = this._cartItemService.ClearCartItems(id);
            if (!isDeleted) return this.BadRequest();

            return this.Ok();
        }
    }
}