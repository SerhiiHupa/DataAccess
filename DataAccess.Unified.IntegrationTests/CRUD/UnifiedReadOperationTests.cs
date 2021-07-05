using System;
using System.Linq;
using System.Threading.Tasks;
using DataAccess.Models;
using DataAccess.Interfaces.Identifier;
using NUnit.Framework;

namespace DataAccess.Unified.IntegrationTests.CRUD
{

    [TestFixture]
    public class UnifiedReadOperationTests : CRUDOperations
    {
        [Test]
        public async Task FindByIdTest()
        {
            var dbEntity = await ReadOperation.Find<TestEntity>(x => x.TestPropertyInt == 1);
            var result = await ReadOperation.FindById<TestEntity>(dbEntity);

            Assert.IsNotNull(result);
            Assert.IsTrue(result.TestPropertyInt == 1 && result.TestPropertyString == "1");
        }

         [Test]
        public async Task FindByEntity()
        {
            var dbEntity = await ReadOperation.Find<TestEntity>(x => x.TestPropertyInt == 1);
            var entity = new TestEntity { TestPropertyInt = 1, TestPropertyString = "1" };
            var testCollection = await ReadOperation.Find<TestEntity>(entity);

            Assert.IsNotNull(testCollection);
            Assert.IsTrue(testCollection.Id == dbEntity.Id);
            Assert.IsTrue(testCollection.TestPropertyInt == 1 && testCollection.TestPropertyString == "1");
        }

        [Test]
        public async Task FindAllByEntity()
        {
            var entity = new TestEntity { TestPropertyInt = 2, TestPropertyString = "2" };
            var testCollection = await ReadOperation.FindAll<TestEntity>(entity);

            Assert.IsNotNull(testCollection);
            Assert.IsTrue(testCollection.Count() > 1);
            Assert.IsTrue(testCollection.All(x => x.TestPropertyInt == 2 && x.TestPropertyString == "2"));
        }

        [Test]
        public async Task FindByPredicate()
        {
            var existedEntity = await ReadOperation.Find<TestEntity>(x => x.TestPropertyInt == 1);
            var testCollection = await ReadOperation.Find<TestEntity>(x => x.Id == existedEntity.Id);

            Assert.IsNotNull(testCollection);
            Assert.IsTrue(testCollection.Id == existedEntity.Id);
            Assert.IsTrue(testCollection.TestPropertyInt == existedEntity.TestPropertyInt && testCollection.TestPropertyString == existedEntity.TestPropertyString);
        }

        [Test]
        public async Task FindAllByPredicate()
        {
            var testCollection = (await ReadOperation.FindAll<TestEntity>(x => x.TestPropertyInt > 1)).ToList();

            Assert.IsNotNull(testCollection);
            Assert.IsTrue(testCollection.Count() > 1);
            Assert.IsTrue(testCollection.All(x => x.TestPropertyInt > 1));
        }
    }
}
