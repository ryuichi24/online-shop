using Microsoft.AspNetCore.Mvc;
using server.Models;
using server.Repositories.OrderRepo;

namespace server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : RootController<Order, OrderRepository>
    {
        public OrderController(OrderRepository repository) : base(repository) { }
    }
}