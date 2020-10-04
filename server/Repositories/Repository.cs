using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace server.Repositories
{
    public abstract class Repository<TModel> : IRepository<TModel> where TModel : class
    {
        protected readonly DbContext _DbContext;

        public Repository(DbContext dbContext)
        {
            this._DbContext = dbContext;
        }

        public void Add(TModel entity)
        {
            this._DbContext.Set<TModel>().Add(entity);
        }

        public IEnumerable<TModel> GetAll()
        {
            return this._DbContext.Set<TModel>().ToList();
        }

        public TModel GetById(int id)
        {
            return this._DbContext.Set<TModel>().Find(id);
        }

        public void Update(TModel entity)
        {
            this._DbContext.Set<TModel>().Update(entity);
        }

        public void Remove(TModel entity)
        {
            this._DbContext.Set<TModel>().Remove(entity);
        }

        public bool SaveChanges()
        {
            return (this._DbContext.SaveChanges() >= 0);
        }

    }
}