using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;

namespace SupplyChain.Infrastructure.Test.Doubles
{
    public class TestDbSet<TEntity> : DbSet<TEntity>, IQueryable, IEnumerable<TEntity>, IDbAsyncEnumerable<TEntity>
      where TEntity : class
    {
        ObservableCollection<TEntity> data;
        IQueryable query;

        public TestDbSet()
        {
            this.data = new ObservableCollection<TEntity>();
            this.query = data.AsQueryable();
        }

        public override TEntity Add(TEntity item)
        {
            this.data.Add(item);
            return item;
        }

        public override TEntity Remove(TEntity item)
        {
            this.data.Remove(item);
            return item;
        }

        public override TEntity Attach(TEntity item)
        {
            this.data.Add(item);
            return item;
        }

        public override TEntity Create()
        {
            return Activator.CreateInstance<TEntity>();
        }

        public override TDerivedEntity Create<TDerivedEntity>()
        {
            return Activator.CreateInstance<TDerivedEntity>();
        }

        public override ObservableCollection<TEntity> Local
        {
            get { return this.data; }
        }

        Type IQueryable.ElementType
        {
            get { return this.query.ElementType; }
        }

        Expression IQueryable.Expression
        {
            get { return this.query.Expression; }
        }

        IQueryProvider IQueryable.Provider
        {
            get { return new TestDbAsyncQueryProvider<TEntity>(this.query.Provider); }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.data.GetEnumerator();
        }

        IEnumerator<TEntity> IEnumerable<TEntity>.GetEnumerator()
        {
            return this.data.GetEnumerator();
        }

        IDbAsyncEnumerator<TEntity> IDbAsyncEnumerable<TEntity>.GetAsyncEnumerator()
        {
            return new TestDbAsyncEnumerator<TEntity>(this.data.GetEnumerator());
        }
    }
}
