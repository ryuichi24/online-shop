using AutoMapper;
using server.Dtos.Admin;
using server.Models;

namespace server.Profiles
{
    public class AdminProfile : Profile
    {
        //
        public AdminProfile()
        {
            CreateMap<Admin, AdminReadDto>();
            CreateMap<AdminCreateDto, Admin>();

            CreateMap<AdminUpdateDto, Admin>()
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
                    dest => dest.Email,
                    opt =>
                    {
                        opt.Condition(src => src.Email != null);
                        opt.MapFrom(src => src.Email);
                    }
                )
                .ForMember
                (
                    dest => dest.Password,
                    opt =>
                    {
                        opt.Condition(src => src.Password != null);
                        opt.MapFrom(src => src.Password);
                    }
                )
                .ForMember
                (
                    dest => dest.Phone,
                    opt =>
                    {
                        opt.Condition(src => src.Phone != null);
                        opt.MapFrom(src => src.Phone);
                    }
                );
        }
    }
}