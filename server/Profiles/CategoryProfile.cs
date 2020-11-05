using AutoMapper;
using server.Dtos.CategoryDto;
using server.Models;

namespace Profiles
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<Category, CategoryReadDto>();
            CreateMap<CategoryCreateDto, Category>();

            CreateMap<CategoryUpdateDto, Category>()
                .ForMember
                (
                    dest => dest.Name,
                    opt =>
                    {
                        opt.Condition(src => src.Name != null);
                        opt.MapFrom(src => src.Name);
                    }
                );
        }
    }
}