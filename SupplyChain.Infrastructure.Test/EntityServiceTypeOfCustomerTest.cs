using Microsoft.VisualStudio.TestTools.UnitTesting;
using SupplyChain.Core;
using SupplyChain.Infrastructure.Services;
using SupplyChain.Infrastructure.Test.Stubs;
using System;
using System.Linq;

namespace SupplyChain.Infrastructure.Test
{
    [TestClass]
    public class EntityServiceTypeOfCustomerTest
    {
        private FakeCrudRepositoryTypeOfCustomer customerRepository;
        private IEntityService<Customer> service;
        private IUnitOfWork unitOfWork;

        [TestInitialize]
        public void Setup()
        {
            this.customerRepository = new FakeCrudRepositoryTypeOfCustomer();
            this.unitOfWork = new FakeUnitOfWork();
            this.service = new EntityService<Customer>(this.customerRepository,this.unitOfWork);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void EntityServiceTypeOfCustomer_ConstructorGivenNullForContextUnitOfWorkParameters_ArgumentNullException()
        {
            this.service = new EntityService<Customer>(null,null);
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void EntityServiceTypeOfCustomer_GetAll_ReturnsCorrectCount()
        {
            var expected = 4;
            var actual = this.service.GetAll().Count();
            Assert.AreEqual(expected,actual);
        }

        [TestMethod]
        public void EntityServiceTypeOfCustomer_GetAllWithInclude_ReturnsCorrectCount()
        {
            var expected = 4;
            var actual = this.service.GetAll(s => s.Orders).Count();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void EntityServiceTypeOfCustomer_GetAllWithFilterAndInclude_ReturnsCorrectCount()
        {
            var expected = 3;
            var actual = this.service.GetAll(s => s.Address.State == "California",s => s.Orders).Count();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void EntityServiceTypeOfCustomer_GetAllWithFilter_ReturnsCorrectCount()
        {
            var expected = 3;
            var actual = this.service.GetAll(s => s.Address.State == "California").Count();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void EntityServiceTypeOfCustomer_Find_ReturnsCorrectCustomer()
        {
            var actual = this.service.Find(2);
            var expected = new Customer { Id = 2, Name = "Telerik", Address = new Address { State = "California", Street = "Golden State", ZipCode = "015" } };
            Assert.IsTrue((actual.Id == expected.Id && actual.Name == expected.Name && actual.Address.State == expected.Address.State && actual.Address.Street == expected.Address.Street && actual.Address.ZipCode == expected.Address.ZipCode));
        }

        [TestMethod]
        public void EntityServiceTypeOfCustomer_One_ReturnsCorrectCustomer()
        {
            var actual = this.service.One(c => c.Id == 2);
            var expected = new Customer { Id = 2, Name = "Telerik", Address = new Address { State = "California", Street = "Golden State", ZipCode = "015" } };
            Assert.IsTrue((actual.Id == expected.Id && actual.Name == expected.Name && actual.Address.State == expected.Address.State && actual.Address.Street == expected.Address.Street && actual.Address.ZipCode == expected.Address.ZipCode));
        }

        [TestMethod]
        public void EntityServiceTypeOfCustomer_OneWithInclude_ReturnsCorrectCustomer()
        {
            var actual = this.service.One(c => c.Id == 2, c => c.Orders);
            var expected = new Customer { Id = 2, Name = "Telerik", Address = new Address { State = "California", Street = "Golden State", ZipCode = "015" } };
            Assert.IsTrue((actual.Id == expected.Id && actual.Name == expected.Name && actual.Address.State == expected.Address.State && actual.Address.Street == expected.Address.Street && actual.Address.ZipCode == expected.Address.ZipCode));
        }

        [TestMethod]
        public void EntityServiceTypeOfCustomer_Add_ReturnsCorrectCustomerCount()
        {
            var expected = this.service.GetAll().Count() + 1;
            this.service.Create(new Customer { });
            this.service.Save();
            var actual = this.service.GetAll().Count();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void EntityServiceTypeOfCustomer_Remove_ReturnsCorrectCustomerCount()
        {
            var expected = this.service.GetAll().Count() - 1;
            this.service.Delete(2);
            this.service.Save();
            var actual = this.service.GetAll().Count();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void EntityServiceTypeOfCustomer_Update_SaveChangesCalledCustomerIsUpdated()
        {
            var entity = this.service.Find(2);
            entity.Name = "New Name";
            var expected = entity.Name;
            this.service.Update(entity);
            this.service.Save();
            var updatedEntity = this.service.Find(2);
            var actual = "New Name";
            Assert.AreEqual(expected, actual);
        }
    }
}
