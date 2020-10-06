using Microsoft.AspNetCore.Mvc;
using server.Models;
using server.DataAccess.Repositories.CartItemRepo;

namespace server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartItemController : RootController<CartItem, ICartItemRepository>
    {
        public CartItemController(ICartItemRepository repository) : base(repository) { }
    }
}