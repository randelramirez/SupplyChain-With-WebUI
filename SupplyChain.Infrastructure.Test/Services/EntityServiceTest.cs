//using System;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using SupplyChain.Core;
//using SupplyChain.Infrastructure.Test.Stubs;
//using System.Linq;

//namespace SupplyChain.Infrastructure.Test.Services
//{
//    [TestClass]
//    public class EntityServiceTest
//    {
//        private Repository<Customer> customerRepository;

//        public void Setup()
//        {
//            this.customerRepository = new FakeCustomerRepository();
//        }

//        [TestMethod]
//        public void TestMethod1()
//        {
            
//            Assert.AreEqual(this.customerRepository.All().Count(), 4);
//        }
//    }
//}
