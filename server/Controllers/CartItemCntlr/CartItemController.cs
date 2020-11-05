using Microsoft.AspNetCore.Mvc;
using server.Models;
using server.DataAccess.Repositories.CartItemRepo;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using server.Helpers;
using AutoMapper;
using server.Dtos.CartItemDto;

namespace server.Controllers.CartItemCntlr
{
    [Authorize(Roles = AuthRole.User)]
    [Route("api/[controller]")]
    [ApiController]
    public class CartItemController : ControllerBase, ICartItemController
    {
        private readonly ICartItemRepository _repository;
        private readonly IMapper _mapper;

        public CartItemController(ICartItemRepository repository, IMapper mapper)
        {
            this._repository = repository;
            this._mapper = mapper;
        }

        [HttpPost]
        public ActionResult<CartItemReadDto> AddNewCartItem([FromBody] CartItemCreateDto cartItemCreateDto)
        {
            var newCartItemModel = this._mapper.Map<CartItem>(cartItemCreateDto);

            this._repository.Add(newCartItemModel);
            this._repository.SaveChanges();

            return this.CreatedAtRoute(new { Id = newCartItemModel.CartItemId }, newCartItemModel);
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
        public ActionResult<IEnumerable<CartItemReadDto>> GetAllCartItemsByUserId(int id)
        {
            return this.Ok(this._mapper.Map<IEnumerable<CartItemReadDto>>(this._repository.GetAllCartItemsByUserId(id)));
        }

        [HttpGet("{id}")]
        public ActionResult<CartItemReadDto> GetCartItemById(int id)
        {
            CartItem cartItem = this._repository.GetById(id);

            if (cartItem == null) return NotFound();

            return this.Ok(this._mapper.Map<CartItemReadDto>(cartItem));
        }

        [HttpPut("{id}")]
        public ActionResult UpdateCartItem(int id, [FromBody] CartItemUpdateDto cartItemUpdateDto)
        {
            CartItem existingCartItem = this._repository.GetById(id);
            if (existingCartItem == null) return this.NotFound();

            this._mapper.Map(cartItemUpdateDto, existingCartItem);

            this._repository.Update(existingCartItem);
            this._repository.SaveChanges();

            return this.NoContent();
        }

        [HttpDelete("clear-cart-items/{id}")]
        public ActionResult ClearCartItems(int id)
        {
            IEnumerable<CartItem> cartItems = this._repository.GetAllCartItemsByUserId(id);

            this._repository.ClearCartItems(cartItems);
            this._repository.SaveChanges();

            return this.Ok();
        }
    }
}