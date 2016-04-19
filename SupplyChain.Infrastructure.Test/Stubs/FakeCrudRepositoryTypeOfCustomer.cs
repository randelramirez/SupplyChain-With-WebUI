using SupplyChain.Core;
using SupplyChain.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace SupplyChain.Infrastructure.Test.Stubs
{
    public class FakeCrudRepositoryTypeOfCustomer : ICrudRepository<Customer> //: Repository<Customer>
    {
        private List<Customer> customers;

        public FakeCrudRepositoryTypeOfCustomer()
        {
            this.customers = new List<Customer>();
            customers.Add(new Customer { Name = "Microsoft", Address = new Address { State = "Washington", Street = "Seattle", ZipCode = "192" } });
            customers.Add(new Customer { Name = "Telerik", Address = new Address { State = "California", Street = "Golden State", ZipCode = "015" } });
            customers.Add(new Customer { Name = "Google", Address = new Address { State = "California", Street = "Mountain View", ZipCode = "010" } });
            customers.Add(new Customer { Name = "Facebook", Address = new Address { State = "California", Street = "Cupertino", ZipCode = "211" } });
        }

        public void Add(Customer entity)
        {
            this.customers.Add(entity);
        }

        public IEnumerable<Customer> All()
        {
            return this.customers;
        }

        public IEnumerable<Customer> All(params Expression<Func<Customer, object>>[] includeProperties)
        {
            return this.customers;
        }

        public IEnumerable<Customer> All(Expression<Func<Customer, bool>> filter)
        {
            return this.customers.AsQueryable().Where(filter);
        }

        public IEnumerable<Customer> All(Expression<Func<Customer, bool>> filter, params Expression<Func<Customer, object>>[] includeProperties)
        {
            return this.customers.AsQueryable().Where(filter);
        }

        public void Delete(int id)
        {
            var entityToDelete = this.customers.Single(c => c.Id == id);
            this.customers.Remove(entityToDelete);
        }

        public Customer Find(int id)
        {
            var entity = this.customers.Single(c => c.Id == id);
            return entity;
        }

        public Customer Single(Expression<Func<Customer, bool>> filter)
        {
            var entityToDelete = this.customers.AsQueryable().Single(filter);
            return entityToDelete;
        }

        public Customer Single(Expression<Func<Customer, bool>> filter, params Expression<Func<Customer, object>>[] includeProperties)
        {
            return this.customers.AsQueryable().Single(filter);
        }

        public void Update(Customer entity)
        {
            var entityToUpdate = this.customers.Single(c => c.Id == entity.Id);
            entityToUpdate = entity;
        }
    }
}
