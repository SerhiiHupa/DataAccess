using System.Threading.Tasks;
using DataAccess.Models;
using NUnit.Framework;

namespace DataAccess.Unified.IntegrationTests.CRUD
{
    [TestFixture]
    public class UnifiedUpdateOperationTests : CRUDOperations
    {
        [Test]
        public async Task Update()
        {
            var dbEntity = await ReadOperation.Find<TestEntity>(x => x.TestPropertyInt == 1);
            dbEntity.TestPropertyInt = 5;
            dbEntity.TestPropertyString = "5";

            dbEntity = await UpdateOperation.Update<TestEntity>(dbEntity);

            var updatedEntity = await ReadOperation.FindById<TestEntity>(dbEntity);

            Assert.IsNotNull(updatedEntity);
            Assert.IsTrue(updatedEntity.Id == dbEntity.Id);
            Assert.IsTrue(updatedEntity.TestPropertyInt == dbEntity.TestPropertyInt && updatedEntity.TestPropertyString == dbEntity.TestPropertyString);
        }
    }
}
