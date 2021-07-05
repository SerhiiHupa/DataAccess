using System.Threading.Tasks;
using DataAccess.Models;
using NUnit.Framework;

namespace DataAccess.Unified.IntegrationTests.CRUD
{
    [TestFixture]
    public class UnifiedCreateOperationTests : CRUDOperations
    {
        [Test]
        public async Task TestCreateOperation()
        {
            var testPropertyInt = 12345;
            var testPropertyString = "11111";

            var testEntity = new TestEntity {
                TestPropertyInt = testPropertyInt,
                TestPropertyString = testPropertyString
            };

            var result = await CreateOperation.Create(testEntity);

            Assert.IsNotNull(result);
            Assert.IsTrue(testEntity.TestPropertyInt == testPropertyInt);
            Assert.IsTrue(testEntity.TestPropertyString == testPropertyString);
       
            var createdEntity = await ReadOperation.Find(testEntity);

            Assert.IsNotNull(createdEntity);
            Assert.IsTrue(createdEntity.TestPropertyInt == testPropertyInt);
            Assert.IsTrue(createdEntity.TestPropertyString == testPropertyString);
        }
    }
}
