using SupplyChain.Core;
using System.Data.Entity;
using System;

namespace SupplyChain.Infrastructure.Test.Stubs
{
    public class FakeSupplyChainContext : FakeDbContext, ISupplyChainContext
    {
        public FakeSupplyChainContext()
        {
            this.Customers = new TestCustomerDbSet();
            this.AddFakeDbSet<Customer, TestCustomerDbSet>(this.Customers);
        }

        public IDbSet<Customer> Customers { get; set; }
       
        public IDbSet<Product> Products { get; set; }
       

        public IDbSet<PurchaseOrderDetail> PurchaseOrderDetails { get; set; }


        public IDbSet<PurchaseOrderHeader> PurchaseOrderHeader { get; set; }
       

        public IDbSet<SalesOrderDetail> SalesOrderDetails { get; set; }
       

        public IDbSet<SalesOrderHeader> SalesOrderHeaders { get; set; }
        

        public IDbSet<Supplier> Suppliers { get; set; }

        IDbSet<T> IDbContext.Set<T>()
        {
            return base.Set<T>();
        }

        public void SetEntityState<T>(T entity, EntityState state) where T : class, new()
        {
            // check if entity is typeof Customer
            // if I implement something like this then I would need a helper method to check for every type of accessible dbset in this context
            //(entity as Customer).Name = "Updated";
            
        }

        public int Save()
        {
            return base.SaveChanges();
        }

    }
}
