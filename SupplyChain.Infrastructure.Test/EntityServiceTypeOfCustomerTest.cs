using Microsoft.VisualStudio.TestTools.UnitTesting;
using SupplyChain.Core;
using SupplyChain.Infrastructure.Services;
using SupplyChain.Infrastructure.Test.Stubs;
using System.Linq;

namespace SupplyChain.Infrastructure.Test
{
    [TestClass]
    public class EntityServiceTypeOfCustomerTest
    {
        private FakeCrudRepositoryTypeOfCustomer customerRepository;
        private EntityService<Customer> service;
        private IUnitOfWork unitOfWork;

        [TestInitialize]
        public void Setup()
        {
            this.customerRepository = new FakeCrudRepositoryTypeOfCustomer();
            this.unitOfWork = new FakeUnitOfWork();
            this.service = new EntityService<Customer>(this.customerRepository,this.unitOfWork);
        }

        [TestMethod]
        public void TestMethod1()
        {
            var expected = 4;
            var actual = this.service.GetAll().Count();
            Assert.AreEqual(expected,actual);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var expected = 4;
            var actual = this.service.GetAll(s => s.Orders).Count();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestMethod3()
        {
            var expected = 3;
            var actual = this.service.GetAll(s => s.Address.State == "California",s => s.Orders).Count();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestMethod4()
        {
            var actual = this.service.Find(2);
            var expected = new Customer { Id = 2, Name = "Telerik", Address = new Address { State = "California", Street = "Golden State", ZipCode = "015" } };
            Assert.IsTrue((actual.Id == expected.Id && actual.Name == expected.Name && actual.Address.State == expected.Address.State && actual.Address.Street == expected.Address.Street && actual.Address.ZipCode == expected.Address.ZipCode));
        }
    }
}
