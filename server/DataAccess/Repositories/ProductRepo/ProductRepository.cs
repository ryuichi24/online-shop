using System.Collections.Generic;
using System.Linq;
using server.DataAccess;
using server.Models;

namespace server.DataAccess.Repositories.ProductRepo
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(OnlineShopDbContext dbContext) : base(dbContext) { }

        public IEnumerable<Product> GetAllProductsByCategoryId(int categoryId)
        {
            return this._DbContext.Set<Product>().Where(p => p.CategoryId == categoryId)
            .ToList();
        }
    }
}