using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupplyChain.Infrastructure.Test.Stubs
{   
    public abstract class FakeDbContext 
    {
        private readonly Dictionary<Type, object> fakeDbSets;

        protected FakeDbContext()
        {
            this.fakeDbSets = new Dictionary<Type, object>();
        }

        public int SaveChanges() { return default(int); }

        //public Task<int> SaveChangesAsync(CancellationToken cancellationToken) { return new Task<int>(() => default(int)); }

        //public Task<int> SaveChangesAsync() { return new Task<int>(() => default(int)); }

        public void Dispose() { }

        public DbSet<T> Set<T>() where T : class, new() { return ((DbSet<T>)this.fakeDbSets[typeof(T)]); }

        public void AddFakeDbSet<TEntity, TFakeDbSet>(IDbSet<TEntity> value)
            where TEntity : class, new()
            where TFakeDbSet : DbSet<TEntity>
        {
            var fakeDbSet = Activator.CreateInstance<TFakeDbSet>();
            fakeDbSet = (value as TFakeDbSet);
            this.fakeDbSets.Add(typeof(TEntity), fakeDbSet);
        }

        public void SyncObjectsStatePostCommit() { }
    }
}
