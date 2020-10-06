using server.DataAccess;
using server.Models;

namespace server.DataAccess.Repositories.CategoryRepo
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(OnlineShopDbContext dbContext) : base(dbContext) {}
    }
}