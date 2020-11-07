using System;
using System.Collections.Generic;
using AutoMapper;
using server.DataAccess.Repositories.OrderItemRepo;
using server.DataAccess.Repositories.OrderRepo;
using server.Dtos.OrderDto;
using server.Models;

namespace Services.OrderService
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IOrderItemRepository _orderItemRepository;
        private readonly IMapper _mapper;

        public OrderService(IOrderRepository orderRepository, IOrderItemRepository orderItemRepository, IMapper mapper)
        {
            this._orderRepository = orderRepository;
            this._orderItemRepository = orderItemRepository;
            this._mapper = mapper;
        }

        public OrderReadDto AddNewOrder(OrderCreateDto orderCreateDto)
        {
            var newOrderModel = this._mapper.Map<Order>(orderCreateDto);

            newOrderModel.OrderedAt = DateTime.Now;

            this._orderRepository.Add(newOrderModel);
            this._orderRepository.SaveChanges();

            newOrderModel.OrderItems.ForEach(orderItem =>
            {
                this._orderItemRepository.Add(new OrderItem
                {
                    OrderId = newOrderModel.OrderId,
                    ProductId = orderItem.ProductId,
                    OrderItemCount = orderItem.OrderItemCount
                });

                this._orderItemRepository.SaveChanges();
            });

            var orderReadDto = this._mapper.Map<OrderReadDto>(newOrderModel);

            return orderReadDto;
        }

        public bool DeleteOrder(int id)
        {
            Order order = this._orderRepository.GetById(id);
            if (order == null) return false;

            this._orderRepository.Remove(order);
            this._orderRepository.SaveChanges();

            return true;
        }

        public IEnumerable<OrderReadDto> GetAllOrders()
        {
            var orders = this._orderRepository.GetAllOrderWithPopulatedChildren();
            if (orders == null) return null;

            var orderReadDtos = this._mapper.Map<IEnumerable<OrderReadDto>>(orders);

            return orderReadDtos;
        }

        public IEnumerable<OrderReadDto> GetAllOrdersByUserId(int id)
        {
            var orders = this._orderRepository.GetAllOrdersByUserId(id);
            if (orders == null) return null;

            var orderReadDtos = this._mapper.Map<IEnumerable<OrderReadDto>>(orders);

            return orderReadDtos;
        }

        public OrderReadDto GetOrderById(int id)
        {
            var order = this._orderRepository.GetById(id);
            if (order == null) return null;

            var orderReadDto = this._mapper.Map<OrderReadDto>(order);

            return orderReadDto;
        }
    }
}