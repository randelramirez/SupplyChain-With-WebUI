using SupplyChain.Core;
using System.Data.Entity;

namespace SupplyChain.Infrastructure
{
    public class SupplyChainContext : DbContext
    {
        public SupplyChainContext()
        {
        }

        public SupplyChainContext(string connectionString) : base(connectionString)
        {
        }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Supplier> Suppliers { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<PurchaseOrderHeader> PurchaseOrderHeader { get; set; }

        public DbSet<PurchaseOrderDetail> PurchaseOrderDetails { get; set; }

        public DbSet<SalesOrderHeader> SalesOrderHeaders { get; set; }

        public DbSet<SalesOrderDetail> SalesOrderDetails { get; set; }

        // TO DO: TPH, TPT, current implementation is TPC, though it is not configured explicitly via the fluent api (model builder)
        //public DbSet<BusinessPartner> BusinessPartners { get; set; }
    }
}
