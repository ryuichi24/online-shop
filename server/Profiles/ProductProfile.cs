using AutoMapper;
using server.Dtos.ProductDto;
using server.Models;

namespace server.Profiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<ProductCreateDto, Product>();
            CreateMap<Product, ProductReadDto>();

            CreateMap<ProductUpdateDto, Product>()
                .ForMember
                (
                    dest => dest.Name,
                    opt =>
                    {
                        opt.Condition(src => src.Name != null);
                        opt.MapFrom(src => src.Name);
                    }
                )
                .ForMember
                (
                    dest => dest.Price,
                    opt =>
                    {
                        opt.Condition(src => src.Price != null);
                        opt.MapFrom(src => src.Price);
                    }
                )
                .ForMember
                (
                    dest => dest.Description,
                    opt =>
                    {
                        opt.Condition(src => src.Description != null);
                        opt.MapFrom(src => src.Description);
                    }
                )
                .ForMember
                (
                    dest => dest.Inventory,
                    opt =>
                    {
                        opt.Condition(src => src.Inventory != null);
                        opt.MapFrom(src => src.Inventory);
                    }
                )
                .ForMember
                (
                    dest => dest.Image,
                    opt =>
                    {
                        opt.Condition(src => src.Image != null);
                        opt.MapFrom(src => src.Image);
                    }
                )
                .ForMember
                (
                    dest => dest.CategoryId,
                    opt =>
                    {
                        opt.Condition(src => src.CategoryId != null);
                        opt.MapFrom(src => src.CategoryId);
                    }
                );
        }
    }
}