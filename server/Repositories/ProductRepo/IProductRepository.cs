using server.Models;

namespace server.Repositories.ProductRepo
{
    public interface IProductRepository : IRepository<Product>
    {
         // add some features specially for Product
    }
}