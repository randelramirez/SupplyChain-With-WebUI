//using SupplyChain.Core;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Linq.Expressions;

//namespace SupplyChain.Infrastructure
//{
//    public class SupplierRepository : ICrudRepository<Supplier>
//    {
//        private SupplyChainContext context;

//        public SupplierRepository(SupplyChainContext context)
//        {
//            if (context == null)
//            {
//                throw new ArgumentNullException("context");
//                //throw new ArgumentNullException(string.Format(nameof(context)));
//            }

//            this.context = context;
//        }

//        public void Add(Supplier entity)
//        {
//            this.context.Set<Supplier>().Add(entity);
//        }

//        public IEnumerable<Supplier> All()
//        {
//            return this.context.Set<Supplier>().AsEnumerable();
//        }

//        public IEnumerable<Supplier> All(Expression<Func<Supplier, bool>> filter)
//        {
//            return this.context.Set<Supplier>().Where(filter).AsEnumerable();
//        }

//        public void Delete(int id)
//        {
//            var entityToDelete = this.context.Set<Supplier>().Find(id);
//            this.context.Set<Supplier>().Remove(entityToDelete);
//        }

//        public Supplier Single(Expression<Func<Supplier, bool>> filter)
//        {
//            return this.context.Set<Supplier>().SingleOrDefault(filter);
//        }

//        public void Update(Supplier entity)
//        {
//            this.context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
//        }
//    }
//}
