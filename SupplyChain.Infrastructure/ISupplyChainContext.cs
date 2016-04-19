using SupplyChain.Core;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupplyChain.Infrastructure
{
    public interface ISupplyChainContext : IDbContext
    {
        IDbSet<Customer> Customers { get; set; }

        IDbSet<Supplier> Suppliers { get; set; }

        IDbSet<Product> Products { get; set; }

        IDbSet<PurchaseOrderHeader> PurchaseOrderHeader { get; set; }

        IDbSet<PurchaseOrderDetail> PurchaseOrderDetails { get; set; }

        IDbSet<SalesOrderHeader> SalesOrderHeaders { get; set; }

        IDbSet<SalesOrderDetail> SalesOrderDetails { get; set; }

    }
}
