using System.Collections.Generic;

namespace server.Repositories
{
    public interface IRepository<TModel> where TModel : class
    {
        TModel GetById(int id);
        IEnumerable<TModel> GetAll();
        void Add(TModel entity);
        void Update(TModel entity);
        void Remove(TModel entity);
        bool SaveChanges();
    }
}