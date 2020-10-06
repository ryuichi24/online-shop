using server.DataAccess;
using server.Models;

namespace server.DataAccess.Repositories.ProductRepo
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(OnlineShopDbContext dbContext) : base(dbContext) { }
    }
}