using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SupplyChain.Infrastructure.Test.Stubs;
using SupplyChain.Core;
using System.Linq;
using Microsoft.QualityTools.Testing.Fakes;

namespace SupplyChain.Infrastructure.Test
{
    [TestClass]
    public class RepositoryTypeOfCustomerTest
    {
        private FakeSupplyChainContext context;
        private Repository<Customer> customerRepository;

        //[TestInitialize]
        private void Setup()
        {
            this.context = new FakeSupplyChainContext
            {
                Customers =
                {
                    new Customer { Id = 1, Name = "Test1" },
                    new Customer { Name = "Test" },
                    new Customer { },
                }
            };

           this.customerRepository = new Repository<Customer>(this.context);

        }

        [TestMethod]
        public void Test()
        {
            this.Setup();
            var actual = this.customerRepository.All().Count();
            var expected = 3;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test2()
        {
            this.Setup();
            var actual = this.customerRepository.Find(1).Name;
            var expected = "Test1";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test3()
        {
            this.Setup();
            //var entity = this.customerRepository.Find(1);
            ////var actual = entity.Name + " updated";
            ////var expected = "Test1 updated";
            //var actual = "Updated";
            //this.customerRepository.Update(entity);
            //Assert.AreEqual(entity.Name, actual);

            var entity = this.customerRepository.Find(1);
            var actual = entity.Name + " updated";
            var expected = "Test1 updated";
            this.customerRepository.Update(entity);
            Assert.AreEqual(expected, actual);
        }
    }
}
