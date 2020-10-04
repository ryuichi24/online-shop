using Microsoft.AspNetCore.Mvc;
using server.Models;
using server.Repositories.CartItemRepo;

namespace server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartItemController : RootController<CartItem, CartItemRepository>
    {
        public CartItemController(CartItemRepository repository) : base(repository) { }
    }
}