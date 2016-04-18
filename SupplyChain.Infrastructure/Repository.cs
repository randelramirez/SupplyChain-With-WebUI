using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SupplyChain.Infrastructure
{
    public class Repository<TEntity> : ICrudRepository<TEntity> where TEntity : class, new()
    {
        private ISupplyChainContext context;
        private IDbSet<TEntity> dbset;

        //public Repository(UnitOfWork unitOfWork)
        //{
        //    this.context = unitOfWork.context;
        //    this.dbset = this.context.Set<TEntity>();
        //}



        public Repository(ISupplyChainContext context)
        {
            if (context == null )
            {
                throw new Exception();
            }

            this.context = context;
            this.dbset = this.context.Set<TEntity>();
        }

        public void Add(TEntity entity)
        { 
            this.dbset.Add(entity);
        }

        public IEnumerable<TEntity> All() 
        {
            return this.dbset.AsEnumerable();
        }

        public IEnumerable<TEntity> All(params Expression<Func<TEntity, object>>[] includeProperties)
        {
            var query = this.dbset.AsQueryable();
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }
            return query;
        }

        public IEnumerable<TEntity> All(Expression<Func<TEntity, bool>> filter) 
        {
            return this.dbset.Where(filter);
        }

        public IEnumerable<TEntity> All(Expression<Func<TEntity, bool>> filter, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            var query = this.dbset.AsQueryable();
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }
            return query.Where(filter);
        }

        //public void Delete(TEntity entity) 
        //{
        //    this.dbset.Remove(entity);
        //}

        //public void DeleteById(int id)
        //{
        //    var entityToDelete = this.dbset.Find(id);
        //    if (entityToDelete != null)
        //        this.dbset.Remove(entityToDelete);
        //}

        public void Delete(int id)
        {
            var entityToDelete = this.dbset.Find(id);
            if (entityToDelete != null)
                this.dbset.Remove(entityToDelete);
        }

        public TEntity Find(int id)
        {
            return this.dbset.Find(id);
        }

        public TEntity Single(Expression<Func<TEntity, bool>> filter)
        {
            return this.dbset.Single(filter);
        }

        public TEntity Single(Expression<Func<TEntity, bool>> filter, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            var query = this.dbset.AsQueryable();
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }
            return query.Single(filter);

        }

        public void Update(TEntity entity)
        {
            //(this.context as DbContext).Entry(entity).State = EntityState.Modified
            this.context.SetEntityState<TEntity>(entity, EntityState.Modified);
        }
    }
}
