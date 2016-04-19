﻿using SupplyChain.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupplyChain.Infrastructure
{
    public class UnitOfWork/*<TEntity>*/ : IUnitOfWork, IDisposable /* where TEntity: class, new()*/
    {
        public readonly ISupplyChainContext context;
        /*private ICrudRepository<TEntity> repository;*/

        public UnitOfWork(SupplyChainContext context /*ICrudRepository<TEntity> repository*/) 
        {
            if (context == null)
            {
                throw new ArgumentNullException();
            }

            this.context = context;
            
        }

        public void Save()
        {
            this.context.Save();
        }

        public void Dispose()
        {
            (this.context as IDisposable).Dispose();
        }
    }
}
