using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupplyChain.Infrastructure
{
    public interface IDbContext
    {
        IDbSet<T> Set<T>() where T : class, new();

        void SetEntityState<T> (T Entity, EntityState state) where T: class, new();

        //save
    }
}
