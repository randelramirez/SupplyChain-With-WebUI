using SupplyChain.Core;
using System.Collections.Generic;
using System.Data.Entity;
using System;

namespace SupplyChain.Infrastructure
{
    public class SupplyChainContext : DbContext, ISupplyChainContext
    {
        public SupplyChainContext()
        {
        }

        public SupplyChainContext(string connectionString) : base(connectionString)
        {
        }

        public IDbSet<Customer> Customers { get; set; }

        public IDbSet<Supplier> Suppliers { get; set; }
               
        public IDbSet<Product> Products { get; set; }
               
        public IDbSet<PurchaseOrderHeader> PurchaseOrderHeader { get; set; }
               
        public IDbSet<PurchaseOrderDetail> PurchaseOrderDetails { get; set; }
               
        public IDbSet<SalesOrderHeader> SalesOrderHeaders { get; set; }
               
        public IDbSet<SalesOrderDetail> SalesOrderDetails { get; set; }

        IDbSet<T> IDbContext.Set<T>()
        {
            return base.Set<T>();
        }

        public void SetEntityState<T>(T entity, EntityState state) where T : class, new()
        {
            this.Entry(entity).State = state;
        }

        // TO DO: TPH, TPT, current implementation is TPC, though it is not configured explicitly via the fluent api (model builder)
        //public DbSet<BusinessPartner> BusinessPartners { get; set; }
    }
}
