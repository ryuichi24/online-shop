using Microsoft.AspNetCore.Mvc;
using server.Models;
using server.Repositories.CategoryRepo;

namespace server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : RootController<Category, CategoryRepository>
    {
        public CategoryController(CategoryRepository repository) : base(repository) { }
    }
}