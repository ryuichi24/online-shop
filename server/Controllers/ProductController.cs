using Microsoft.AspNetCore.Mvc;
using server.Models;
using server.Repositories.ProductRepo;

namespace server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : RootController<Product, ProductRepository>
    {
        public ProductController(ProductRepository repository) : base(repository) { }
    }
}