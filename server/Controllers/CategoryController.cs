using Microsoft.AspNetCore.Mvc;
using server.Models;
using server.Repositories.CategoryRepo;

namespace server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : RootController<Category, ICategoryRepository>
    {
        public CategoryController(ICategoryRepository repository) : base(repository) { }
    }
}