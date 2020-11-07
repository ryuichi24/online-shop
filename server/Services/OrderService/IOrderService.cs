using System.Collections.Generic;
using server.Dtos.OrderDto;

namespace Services.OrderService
{
    public interface IOrderService
    {
        IEnumerable<OrderReadDto> GetAllOrders();

        IEnumerable<OrderReadDto> GetAllOrdersByUserId(int id);

        OrderReadDto GetOrderById(int id);

        bool DeleteOrder(int id);

        OrderReadDto AddNewOrder(OrderCreateDto orderCreateDto);
    }
}