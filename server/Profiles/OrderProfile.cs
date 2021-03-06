using AutoMapper;
using Dtos.OrderDto;
using server.Dtos.OrderDto;
using server.Models;

namespace server.Profiles
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<Order, OrderReadDto>();

            CreateMap<OrderCreateDto, Order>();

            CreateMap<OrderItemCreateDto, OrderItem>();

            CreateMap<OrderItem, OrderItemReadDto>();
        }
    }
}
