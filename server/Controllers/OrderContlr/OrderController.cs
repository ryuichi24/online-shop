using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using server.Dtos.OrderDto;
using Services.OrderService;

namespace server.Controllers.OrderContlr
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase, IOrderController
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            this._orderService = orderService;
        }

        /// <summary>
        /// add a new order
        /// </summary>
        /// <param name="orderCreateDto"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult<OrderReadDto> AddNewOrder([FromBody] OrderCreateDto orderCreateDto)
        {
            var orderReadDto = this._orderService.AddNewOrder(orderCreateDto);
            if (orderReadDto == null) return this.BadRequest();

            return this.CreatedAtRoute(new { Id = orderReadDto.OrderId }, orderReadDto);
        }

        /// <summary>
        /// delete an order by an order Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public ActionResult DeleteOrder(int id)
        {
            var isDeleted = this._orderService.DeleteOrder(id);
            if (!isDeleted) return this.BadRequest();

            return this.NoContent();
        }

        /// <summary>
        /// get all orders
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<IEnumerable<OrderReadDto>> GetAllOrders()
        {   var orderReadDtos = this._orderService.GetAllOrders();
            if (orderReadDtos == null) return this.NotFound();

            return this.Ok(orderReadDtos);
        }

        /// <summary>
        /// get all orders by a user Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("all-by-user/{id}")]
        public ActionResult<IEnumerable<OrderReadDto>> GetAllOrdersByUserId(int id)
        {
            var orderReadDtos = this._orderService.GetAllOrdersByUserId(id);
            if (orderReadDtos == null) return this.NotFound();

            return this.Ok(orderReadDtos);
        }

        /// <summary>
        /// get an irder by an order Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public ActionResult<OrderReadDto> GetOrderById(int id)
        {
            var orderReadDto = this._orderService.GetOrderById(id);
            if (orderReadDto == null) return this.NotFound();

            return this.Ok(orderReadDto);
        }
    }
}