using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SupplyChain.Infrastructure.Services
{
    public class EntityService<TEntity> : IEntityService<TEntity> where TEntity : class, new()
    {
        private ICrudRepository<TEntity> repository;

        private IUnitOfWork unitOfWork;

        public EntityService(ICrudRepository<TEntity> repository, IUnitOfWork unitOfWork)
        {
            this.repository = repository;
            this.unitOfWork = unitOfWork;
        }

        public void Create(TEntity entity)
        {
            this.repository.Add(entity);
        }

        public void Delete(int id)
        {
            this.repository.Delete(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return this.repository.All();
        }

        public IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>> filter)
        {
            return this.repository.All(filter);
        }

        public IEnumerable<TEntity> GetAll(params Expression<Func<TEntity, object>>[] includeProperties)
        {
            return this.repository.All(includeProperties);
        }
        public IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>> filter, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            return this.repository.All(filter, includeProperties);
        }

        public TEntity Find(int id)
        {
            return this.repository.Find(id);
        }

        public TEntity One(Expression<Func<TEntity, bool>> filters)
        {
            return this.repository.Single(filters);
        }

        public void Save()
        {
            this.unitOfWork.Save();
        }

        public void Update(TEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
