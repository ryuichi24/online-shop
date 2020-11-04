using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using server.Dtos.OrderDto;

namespace server.Controllers.OrderContlr
{
    public interface IOrderController
    {
        public ActionResult<IEnumerable<OrderReadDto>> GetAllOrders();

        public ActionResult<IEnumerable<OrderReadDto>> GetAllOrdersByUserId(int id);

        public ActionResult<OrderReadDto> GetOrderById(int id);

        public ActionResult DeleteOrder(int id);

        public ActionResult<OrderReadDto> AddNewOrder([FromBody] OrderCreateDto orderCreateDto);
    }
}