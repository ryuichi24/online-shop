using AutoMapper;
using server.Dtos.User;
using server.Models;

namespace server.Profiles
{
    public class UserProfile: Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserReadDto>();
            CreateMap<UserCreateDto, User>();

            CreateMap<UserUpdateDto, User>()
                .ForMember
                (
                    dest => dest.FirstName,
                    opt =>
                    {
                        opt.Condition(src => src.FirstName != null);
                        opt.MapFrom(src => src.FirstName);
                    }
                )
                .ForMember
                (
                    dest => dest.LastName,
                    opt =>
                    {
                        opt.Condition(src => src.LastName != null);
                        opt.MapFrom(src => src.LastName);
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