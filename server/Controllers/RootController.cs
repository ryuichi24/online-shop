using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using server.Repositories;

namespace server.Controllers
{
    public abstract class RootController<TModel, TRepository> : ControllerBase where TModel : class where TRepository : IRepository<TModel>
    {
        private readonly TRepository _repository;

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

        [HttpPost]
        public virtual ActionResult<TModel> AddNewEntity([FromBody] TModel item)
        {
            this._repository.Add(item);
            this._repository.SaveChanges();

            return this.Ok(item);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateEntity(int id, [FromBody] TModel entityToUpdate)
        {
            TModel entity = this._repository.GetById(id);
            if (entity == null) return NotFound();

            this._repository.Update(entityToUpdate);
            this._repository.SaveChanges();

            return this.NoContent();
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