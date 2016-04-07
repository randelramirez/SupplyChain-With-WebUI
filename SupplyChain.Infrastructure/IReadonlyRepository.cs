using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SupplyChain.Infrastructure
{
    public interface IReadonlyRepository<TEntity> where TEntity: class, new()
    {
        TEntity Single(Expression<Func<TEntity, bool>> filter);

        TEntity Find(int id);

        IEnumerable<TEntity> All(); 

        IEnumerable<TEntity> All(Expression<Func<TEntity, bool>> filter);

        IEnumerable<TEntity> All(params System.Linq.Expressions.Expression<Func<TEntity, object>>[] includeProperties);//where TEntity : class, new();

        IEnumerable<TEntity> All(Expression<Func<TEntity, bool>> filter, params System.Linq.Expressions.Expression<Func<TEntity, object>>[] includeProperties);


    }
}
