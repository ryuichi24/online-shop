using AutoMapper;
using server.Dtos.AddressDto;
using server.Models;

namespace server.Profiles
{
    public class AddressProfile : Profile
    {
        public AddressProfile()
        {
            CreateMap<Address, AddressReadDto>();
            CreateMap<AddressCreateDto, Address>();

            CreateMap<AddressUpdateDto, Address>()
                .ForMember
                (
                    dest => dest.Address1,
                    opt =>
                    {
                        opt.Condition(src => src.Address1 != null);
                        opt.MapFrom(src => src.Address1);
                    }
                )
                .ForMember
                (
                    dest => dest.Address2,
                    opt =>
                    {
                        opt.Condition(src => src.Address2 != null);
                        opt.MapFrom(src => src.Address2);
                    }
                )
                .ForMember
                (
                    dest => dest.City,
                    opt =>
                    {
                        opt.Condition(src => src.City != null);
                        opt.MapFrom(src => src.City);
                    }
                )
                .ForMember
                (
                    dest => dest.PostCode,
                    opt =>
                    {
                        opt.Condition(src => src.PostCode != null);
                        opt.MapFrom(src => src.PostCode);
                    }
                )
                .ForMember
                (
                    dest => dest.UserId,
                    opt =>
                    {
                        opt.Condition(src => src.UserId != null);
                        opt.MapFrom(src => src.UserId);
                    }
                );
        }
    }
}