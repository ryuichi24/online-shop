using server.Models;

namespace server.DataAccess.Repositories.ProductRepo
{
    public interface IProductRepository : IRepository<Product>
    {
         // add some features specially for Product
    }
}