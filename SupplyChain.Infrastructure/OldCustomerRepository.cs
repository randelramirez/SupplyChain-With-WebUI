using SupplyChain.Core;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupplyChain.Infrastructure
{
    public class OldCustomerRepository
    {
        private SupplyChainContext context;

        public OldCustomerRepository()
        {
            this.context = new SupplyChainContext();
        }

        public OldCustomerRepository(SupplyChainContext context)
        {
            this.context = context;
        }

        public void Add(Customer customer)
        {
            this.context.Customers.Add(customer);
        }

        public void Update(Customer customer)
        {
            context.Entry(customer).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            var entity = this.context.Customers.Find(id);
            this.context.Customers.Remove(entity);
        }

        public void Save()
        {
            this.context.SaveChanges();
        }
    }
}
