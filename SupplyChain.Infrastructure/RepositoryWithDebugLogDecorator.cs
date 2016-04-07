using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SupplyChain.Infrastructure
{
    public class RepositoryWithDebugLogDecorator<TEntity> : ICrudRepository<TEntity> where TEntity : class, new()
    {
        ICrudRepository<TEntity> repository;

        //ILogger

        //Add an ILogger for logging
        public RepositoryWithDebugLogDecorator(ICrudRepository<TEntity> repository)
        {
            this.repository = repository;
        }

        public void Add(TEntity entity) 
        {
            Debug.WriteLine("Adding");
            this.repository.Add(entity);
            Debug.WriteLine("Added");
        }

        public IEnumerable<TEntity> All() 
        {
            Debug.WriteLine("Getting all");
            return this.repository.All();
            
        }

        public IEnumerable<TEntity> All(params Expression<Func<TEntity, object>>[] includeProperties)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TEntity> All(Expression<Func<TEntity, bool>> filter)
        {
            Debug.WriteLine("Getting all with filter");
            return this.repository.All(filter);
        }

        public IEnumerable<TEntity> All(Expression<Func<TEntity, bool>> filter, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            Debug.WriteLine("Deleting by id");
            this.repository.Delete(id);
        }

        public TEntity Find(int id)
        {
            Debug.WriteLine("Looking");
            return this.repository.Find(id);
        }

        public TEntity Single(Expression<Func<TEntity, bool>> filter)
        {
            Debug.WriteLine("Getting an entity");
            return this.repository.Single(filter);
        }

        public TEntity Single(Expression<Func<TEntity, bool>> filter, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            throw new NotImplementedException();
        }

        public void Update(TEntity entity)
        {
            Debug.WriteLine("Updating");
            this.repository.Update(entity);
            Debug.WriteLine("Updated");
        }
    }
}
