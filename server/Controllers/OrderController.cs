using Microsoft.AspNetCore.Mvc;
using server.Models;
using server.DataAccess.Repositories.OrderRepo;

namespace server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : RootController<Order, IOrderRepository>
    {
        public OrderController(IOrderRepository repository) : base(repository) { }
    }
}