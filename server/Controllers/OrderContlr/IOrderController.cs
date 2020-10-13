using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using server.Helpers.ParameterClass;
using server.Models;

namespace server.Controllers.OrderContlr
{
    public interface IOrderController
    {
        public ActionResult<IEnumerable<Order>> GetAllOrders();

        public ActionResult<IEnumerable<Order>> GetAllOrdersByUserId(int id);

        public ActionResult<Order> GetOrderById(int id);

        public ActionResult DeleteOrder(int id);

        public ActionResult<Order> AddNewOrder([FromBody] OrderCreateParameter orderCreateParameter);
    }
}