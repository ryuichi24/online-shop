using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using server.Repositories;

namespace server.Controllers
{
    public abstract class RootController<TModel, TRepository> : ControllerBase where TModel : class where TRepository : IRepository<TModel>
    {
        protected readonly TRepository _repository;

        public RootController(TRepository repository)
        {
            this._repository = repository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<TModel>> GetAllEntities()
        {
            return this.Ok(this._repository.GetAll());
        }

        [HttpGet("{id}")]
        public ActionResult<TModel> GetEntityById(int id)
        {
            TModel entity = this._repository.GetById(id);

            if (entity == null) return NotFound();

            return this.Ok(entity);
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteEntity(int id)
        {
            TModel entity = this._repository.GetById(id);
            if (entity == null) return NotFound();

            this._repository.Remove(entity);
            this._repository.SaveChanges();

            return this.NoContent();
        }

    }
}