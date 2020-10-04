using server.DataAccess;
using server.Models;

namespace server.Repositories.CategoryRepo
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(OnlineShopDbContext dbContext) : base(dbContext) {}
    }
}