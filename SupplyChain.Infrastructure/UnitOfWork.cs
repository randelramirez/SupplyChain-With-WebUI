using SupplyChain.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupplyChain.Infrastructure
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        public readonly ISupplyChainContext context;
        /*private ICrudRepository<TEntity> repository;*/

        public UnitOfWork(ISupplyChainContext context) 
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
