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

        [HttpPost]
        public ActionResult<OrderReadDto> AddNewOrder([FromBody] OrderCreateDto orderCreateDto)
        {
            var orderReadDto = this._orderService.AddNewOrder(orderCreateDto);
            if (orderReadDto == null) return this.BadRequest();

            return this.CreatedAtRoute(new { Id = orderReadDto.OrderId }, orderReadDto);
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteOrder(int id)
        {
            var isDeleted = this._orderService.DeleteOrder(id);
            if (!isDeleted) return this.BadRequest();

            return this.NoContent();
        }

        [HttpGet]
        public ActionResult<IEnumerable<OrderReadDto>> GetAllOrders()
        {   var orderReadDtos = this._orderService.GetAllOrders();
            if (orderReadDtos == null) return this.NotFound();

            return this.Ok(orderReadDtos);
        }

        [HttpGet("all-by-user/{id}")]
        public ActionResult<IEnumerable<OrderReadDto>> GetAllOrdersByUserId(int id)
        {
            var orderReadDtos = this._orderService.GetAllOrdersByUserId(id);
            if (orderReadDtos == null) return this.NotFound();

            return this.Ok(orderReadDtos);
        }

        [HttpGet("{id}")]
        public ActionResult<OrderReadDto> GetOrderById(int id)
        {
            var orderReadDto = this._orderService.GetOrderById(id);
            if (orderReadDto == null) return this.NotFound();

            return this.Ok(orderReadDto);
        }
    }
}