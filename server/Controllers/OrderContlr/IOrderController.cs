using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using server.Dtos.OrderDto;

namespace server.Controllers.OrderContlr
{
    public interface IOrderController
    {
        ActionResult<IEnumerable<OrderReadDto>> GetAllOrders();

        ActionResult<IEnumerable<OrderReadDto>> GetAllOrdersByUserId(int id);

        ActionResult<OrderReadDto> GetOrderById(int id);

        ActionResult DeleteOrder(int id);

        ActionResult<OrderReadDto> AddNewOrder([FromBody] OrderCreateDto orderCreateDto);
    }
}