//using SupplyChain.Core;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Linq.Expressions;
//using System.Text;
//using System.Threading.Tasks;

//namespace SupplyChain.Infrastructure
//{
//    public class CustomerRepository<> : ICrudRepository<Customer>
//    {
//        private SupplyChainContext context;

//        public CustomerRepository(SupplyChainContext context)
//        {
//            if (context == null)
//            {
//                throw new ArgumentNullException("");
//            }

//            this.context = context;
//        }

//        public void Add(Customer entity)
//        {
//            this.context.Set<Customer>();
//            this.Add(entity);
//        }

//        public IEnumerable<Customer> All()
//        {
//            return this.context.Set<Customer>().AsEnumerable();
//        }

//        public IEnumerable<Customer> All(Expression<Func<Customer, bool>> filter)
//        {
//            return this.context.Set<Customer>().Where(filter);

//        }

//        public void Delete(int id)
//        {
//            throw new NotImplementedException();
//        }
        
//        public Customer Single(Expression<Func<Customer, bool>> filter)
//        {
//            return this.context.Set<Customer>().SingleOrDefault(filter);
//        }

//        public void Update(Customer entity)
//        {
//            this.context.Entry<Customer>(entity).State = System.Data.Entity.EntityState.Modified;
//        }
//    }
//}
