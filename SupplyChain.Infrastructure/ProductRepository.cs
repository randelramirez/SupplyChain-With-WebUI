//using SupplyChain.Core;
//using System;
//using System.Collections.Generic;
//using System.Data.Entity;
//using System.Linq;
//using System.Linq.Expressions;

//namespace SupplyChain.Infrastructure
//{
//    public class ProductRepository : ICrudRepository<Product>
//    {
//        private SupplyChainContext context; 

//        public ProductRepository(SupplyChainContext context)
//        {
//            if (context == null)
//            {
//                throw new ArgumentNullException();
//            }

//            this.context = context;
//        }

//        public void Add(Product entity)
//        {
//            this.context.Set<Product>().Add(entity);
//        }

//        public IEnumerable<Product> All()
//        {
//            return this.context.Set<Product>().AsEnumerable();
//        }

//        public IEnumerable<Product> All(Expression<Func<Product, bool>> filter)
//        {
//            return this.context.Set<Product>().Where(filter).AsEnumerable();
//        }

//        public void Delete(int id)
//        {
//            var entityToDelete = this.context.Set<Product>().Find(id);
//            this.context.Set<Product>().Remove(entityToDelete);
            
//        }

//        public Product Single(Expression<Func<Product, bool>> filter)
//        {
//            return this.context.Set<Product>().SingleOrDefault(filter);
//        }

//        public void Update(Product entity)
//        {
//            this.context.Entry(entity).State = EntityState.Modified;
//        }
//    }
//}
