using AutoMapper;
using server.Dtos.CartItemDto;
using server.Models;

namespace server.Profiles
{
    public class CartItemProfile : Profile
    {
        public CartItemProfile()
        {
            CreateMap<CartItem, CartItemReadDto>();
            CreateMap<CartItemCreateDto, CartItem>();

            CreateMap<CartItemUpdateDto, CartItem>()
                .ForMember
                (
                    dest => dest.CartItemCount,
                    opt =>
                    {
                        opt.Condition(src => src != null);
                        opt.MapFrom(src => src.CartItemCount);
                    }
                );
        }

    }
}