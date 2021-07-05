using System.Threading.Tasks;
using DataAccess.Models;
using NUnit.Framework;

namespace DataAccess.Unified.IntegrationTests.CRUD
{
    [TestFixture]
    public class UnifiedDeleteOperationTests : CRUDOperations
    {
        [Test]
        public async Task DeleteById()
        {
            var dbEntity = await ReadOperation.Find<TestEntity>(x => x.TestPropertyInt == 1);
            var isDeleted = await DeleteOperation.DeleteById<TestEntity>(dbEntity);
            Assert.IsTrue(isDeleted);

            var testCollection = await ReadOperation.FindById<TestEntity>(dbEntity);
            Assert.IsNull(testCollection);
        }

        [Test]
        public async Task DeleteByEntity()
        {
            var entity = new TestEntity { TestPropertyInt = 1, TestPropertyString = "1" };
            var isDeleted = await DeleteOperation.Delete(entity);
            Assert.IsTrue(isDeleted);

            var testCollection = await ReadOperation.Find<TestEntity>(entity);
            Assert.IsNull(testCollection);
        }

        [Test]
        public async Task DeleteAll()
        {
            var isDeleted = await DeleteOperation.DeleteAll<TestEntity>();
            Assert.IsTrue(isDeleted);

            var testCollection = await ReadOperation.FindAll<TestEntity>(x => true);

            Assert.IsEmpty(testCollection);
        }

        [Test]
        public async Task DeleteByPredicate()
        {
            var isDeleted = await DeleteOperation.Delete<TestEntity>(x => x.TestPropertyInt > 2);
            Assert.IsTrue(isDeleted);

            var testCollection = await ReadOperation.FindAll<TestEntity>(x => x.TestPropertyInt > 2);

            Assert.IsEmpty(testCollection);
        }
    }
}
