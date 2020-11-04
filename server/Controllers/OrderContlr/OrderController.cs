using Microsoft.AspNetCore.Mvc;
using server.Models;
using server.DataAccess.Repositories.OrderRepo;
using server.Helpers.ParameterClass;
using System.Collections.Generic;
using server.DataAccess.Repositories.OrderItemRepo;
using System;
using Microsoft.AspNetCore.Authorization;
using server.Helpers;
using AutoMapper;
using server.Dtos.OrderDto;

namespace server.Controllers.OrderContlr
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase, IOrderController
    {
        private readonly IOrderRepository _orderRepository;

        private readonly IOrderItemRepository _orderItemRepository;
        private readonly IMapper _mapper;

        public OrderController(IOrderRepository orderRepository, IOrderItemRepository orderItemRepository, IMapper mapper)
        {
            this._orderRepository = orderRepository;
            this._orderItemRepository = orderItemRepository;
            this._mapper = mapper;
        }

        [HttpPost]
        public ActionResult<OrderReadDto> AddNewOrder([FromBody] OrderCreateDto orderCreateDto)
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

            return this.CreatedAtRoute(new { Id = newOrderModel.OrderId }, newOrderModel);
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteOrder(int id)
        {
            Order order = this._orderRepository.GetById(id);
            if (order == null) return NotFound();

            this._orderRepository.Remove(order);
            this._orderRepository.SaveChanges();

            return this.NoContent();
        }

        [HttpGet]
        public ActionResult<IEnumerable<OrderReadDto>> GetAllOrders()
        {
            return this.Ok(this._mapper.Map<IEnumerable<OrderReadDto>>(this._orderRepository.GetAllOrderWithPopulatedChildren()));
        }

        [HttpGet("all-by-user/{id}")]
        public ActionResult<IEnumerable<OrderReadDto>> GetAllOrdersByUserId(int id)
        {
            return this.Ok(this._mapper.Map<IEnumerable<OrderReadDto>>(this._orderRepository.GetAllOrdersByUserId(id)));
        }

        [HttpGet("{id}")]
        public ActionResult<OrderReadDto> GetOrderById(int id)
        {
            Order order = this._orderRepository.GetById(id);
            if (order == null) return NotFound();

            return this.Ok(this._mapper.Map<OrderReadDto>(order));
        }
    }
}