using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupplyChain.Infrastructure.Test.Doubles
{
    public interface IFakeDbContext
    {
        DbSet<T> Set<T>() where T : class, new();

        void AddFakeDbSet<TEntity, TFakeDbSet>()
            where TEntity : class, new()
            where TFakeDbSet : DbSet<TEntity>, IDbSet<TEntity>, new();
    }
}
