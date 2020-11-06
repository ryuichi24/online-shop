using System.Collections.Generic;
using AutoMapper;
using server.DataAccess.Repositories.CartItemRepo;
using server.Dtos.CartItemDto;
using server.Models;

namespace Services.CartItemService
{
    public class CartItemService : ICartItemService
    {
        private readonly ICartItemRepository _repository;
        private readonly IMapper _mapper;

        public CartItemService(ICartItemRepository repository, IMapper mapper)
        {
            this._repository = repository;
            this._mapper = mapper;
        }

        public CartItemReadDto AddNewCartItem(CartItemCreateDto cartItemCreateDto)
        {
            var newCartItemModel = this._mapper.Map<CartItem>(cartItemCreateDto);

            this._repository.Add(newCartItemModel);
            this._repository.SaveChanges();

            var cartItemReadDto = this._mapper.Map<CartItemReadDto>(newCartItemModel);

            return cartItemReadDto;
        }

        public bool ClearCartItems(int id)
        {
            IEnumerable<CartItem> cartItems = this._repository.GetAllCartItemsByUserId(id);
            if (cartItems == null) return false;

            this._repository.ClearCartItems(cartItems);
            this._repository.SaveChanges();

            return true;
        }

        public bool DeleteCartItem(int id)
        {
            CartItem cartItem = this._repository.GetById(id);
            if (cartItem == null) return false;

            this._repository.Remove(cartItem);
            this._repository.SaveChanges();

            return true;
        }

        public IEnumerable<CartItemReadDto> GetAllCartItemsByUserId(int id)
        {
            var cartItems = this._repository.GetAllCartItemsByUserId(id);
            if (cartItems == null) return null;

            var cartItemReadDtos = this._mapper.Map<IEnumerable<CartItemReadDto>>(cartItems);
            return cartItemReadDtos;
        }

        public CartItemReadDto GetCartItemById(int id)
        {
            CartItem cartItem = this._repository.GetById(id);
            if (cartItem == null) return null;

            var cartItemReadDto = this._mapper.Map<CartItemReadDto>(cartItem);

            return cartItemReadDto;
        }

        public bool UpdateCartItem(int id, CartItemUpdateDto cartItemUpdateDto)
        {
            CartItem existingCartItem = this._repository.GetById(id);
            if (existingCartItem == null) return false;

            this._mapper.Map(cartItemUpdateDto, existingCartItem);

            this._repository.Update(existingCartItem);
            this._repository.SaveChanges();

            return true;
        }
    }
}