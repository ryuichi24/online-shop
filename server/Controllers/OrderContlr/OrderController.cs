using Microsoft.AspNetCore.Mvc;
using server.Models;
using server.DataAccess.Repositories.OrderRepo;
using server.Helpers.ParameterClass;
using System.Collections.Generic;
using server.DataAccess.Repositories.OrderItemRepo;
using System;

namespace server.Controllers.OrderContlr
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase, IOrderController
    {
        private readonly IOrderRepository _orderRepository;

        private readonly IOrderItemRepository _orderItemRepository;

        public OrderController(IOrderRepository orderRepository, IOrderItemRepository orderItemRepository)
        {
            this._orderRepository = orderRepository;
            this._orderItemRepository = orderItemRepository;
        }

        [HttpPost]
        public ActionResult<Order> AddNewOrder([FromBody] OrderCreateParameter orderCreateParameter)
        {
            Order newOrder = new Order()
            {
                TotalPayment = orderCreateParameter.TotalPayment,
                AddressId = orderCreateParameter.AddressId,
                UserId = orderCreateParameter.UserId,
                OrderedAt = DateTime.Now,
            };

            this._orderRepository.Add(newOrder);
            this._orderRepository.SaveChanges();

            orderCreateParameter.OrderItems.ForEach(orderItem =>
            {
                this._orderItemRepository.Add(new OrderItem
                {
                    OrderId = newOrder.OrderId,
                    ProductId = orderItem.ProductId,
                    OrderItemCount = orderItem.OrderItemCount
                });

                this._orderItemRepository.SaveChanges();
            });

            return this.CreatedAtRoute(new { Id = newOrder.OrderId }, newOrder);
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

        [HttpGet("all-by-user/{id}")]
        public ActionResult<IEnumerable<Order>> GetAllOrdersByUserId(int id)
        {
            throw new System.NotImplementedException();
        }

        [HttpGet("{id}")]
        public ActionResult<Order> GetOrderById(int id)
        {
            Order order = this._orderRepository.GetById(id);
            if (order == null) return NotFound();

            return this.Ok(order);
        }
    }
}