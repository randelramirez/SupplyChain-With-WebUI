﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace SupplyChain.Infrastructure.Services
{
    public interface IEntityService<TEntity> where TEntity : class, new()
    {
        IEnumerable<TEntity> GetAll();

        IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>> filter);

        IEnumerable<TEntity> GetAll(params Expression<Func<TEntity, object>>[] includeProperties);

        IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>> filter, params Expression<Func<TEntity, object>>[] includeProperties);

        TEntity One(Expression<Func<TEntity, bool>> filter);

        TEntity One(Expression<Func<TEntity, bool>> filter, params Expression<Func<TEntity, object>>[] includeProperties);

        TEntity Find(int id);

        void Create(TEntity entity);
        
        void Update(TEntity entity);

        void Delete(int id);

        void Save();
    }
}
