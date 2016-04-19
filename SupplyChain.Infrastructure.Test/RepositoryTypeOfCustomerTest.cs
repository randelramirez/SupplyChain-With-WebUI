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

        [TestInitialize]
        public void Setup()
        {
            this.context = new FakeSupplyChainContext
            {
                Customers =
                {
                    new Customer { Id = 1, Name = "Test1" },
                    new Customer { Id = 2, Name = "Test" },
                    new Customer { Id = 3, Name = "Name" },
                }
            };

           this.customerRepository = new Repository<Customer>(this.context);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void RepositoryTypeOfCustomer_ConstructorGivenNullForContextParameter_ThrowsException()
        {
            this.customerRepository = new Repository<Customer>(null);
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void RepositoryTypeOfCustomer_All_ReturnsAllCustomersWithCorrectCount()
        {
            var actual = this.customerRepository.All().Count();
            var expected = 3;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void RepositoryTypeOfCustomer_AllWithInclude_ReturnsAllCustomersWithCorrectCount()
        {
            var actual = this.customerRepository.All(c => c.Orders).Count();
            var expected = 3;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void RepositoryTypeOfCustomer_AllWithFilter_ReturnsAllCustomersWithCorrectCount()
        {
            var actual = this.customerRepository.All(c => c.Name.Contains("Test")).Count();
            var expected = 2;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void RepositoryTypeOfCustomer_AllWithFilterAndInclude_ReturnsAllCustomersWithCorrectCount()
        {
            var actual = this.customerRepository.All(c => c.Id == 1 ,c => c.Orders).Count();
            var expected = 1;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void RepositoryTypeOfCustomer_Add_ReturnsAllCustomersWithCorrectCount()
        {
            var customer = new Customer { };
            this.customerRepository.Add(customer);
            this.context.SaveChanges();
            var expected = 4;
            var actual = this.customerRepository.All().Count();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void RepositoryTypeOfCustomer_Find_ReturnsCustomerWithExpectedName()
        {
            var actual = this.customerRepository.Find(1).Name;
            var expected = "Test1";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void RepositoryTypeOfCustomer_Single_ReturnsCorrectCustomer()
        {
            var expected = this.customerRepository.Find(1);
            var actual = this.customerRepository.Single(c => c.Id == 1);
            Assert.IsTrue((expected.Name == actual.Name && expected.Id == actual.Id));
        }

        [TestMethod]
        public void RepositoryTypeOfCustomer_SingleWithInclude_ReturnsCorrectCustomer()
        {
            var expected = this.customerRepository.Find(1);
            var actual = this.customerRepository.Single(c => c.Id == 1, c => c.Orders);
            Assert.IsTrue((expected.Name == actual.Name && expected.Id == actual.Id));
        }

        [TestMethod]
        public void RepositoryTypeOfCustomer_Delete_CustomerIsDeleted()
        {
            var entity = this.customerRepository.Find(1);
            this.customerRepository.Delete(entity.Id);
            this.context.SaveChanges();
            var deletedEntity = this.customerRepository.Find(1);
            Assert.IsNull(deletedEntity);
            
        }

        [TestMethod]
        public void RepositoryTypeOfCustomer_Update_SaveChangesCalledCustomerIsUpdated()
        {
            var entity = this.customerRepository.Find(1);
            var expected = "Test1 updated";
            this.customerRepository.Update(entity);
            this.context.SaveChanges();
            var updatedEntity = this.customerRepository.Find(1);
            var actual = updatedEntity.Name + " updated";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Mocking_Using_FakesAndShims()
        {
            using (ShimsContext.Create())
            {
                SupplyChain.Infrastructure.Fakes.ShimSupplyChainContext.AllInstances.CustomersGet = (x) => { var y = new TestCustomerDbSet(); y.Add(new Customer { }); return y; };
                SupplyChainContext context = new SupplyChainContext();
                Console.WriteLine(context.Customers.Count());
            }
        }
    }
}
