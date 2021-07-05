using System.Linq;
using System.Threading.Tasks;
using DataAccess.Models;
using DataAccess.PostgreSQL.CRUD;
using DataAccess.PostgreSQL.Infrastructure;
using DataAccess.PredicateInfrastructure;
using DataAccess.Unified.IntegrationTests;
using NUnit.Framework;

namespace DataAccess.PostgreSQL.IntegrationTests.CRUD
{
    [TestFixture]
    public class UnitOfWorkTests : CRUDOperations
    {
        private DataContext _dataContext;

        [SetUp]
        public void SetUp()
        {
            _dataContext = new DataContext();

            SetUpHelper.SetUpWithoutForceSave(this, _dataContext);
        }

        [TearDown]
        public void TearDown()
        {
            ClearDatabaseHelper.Clear();
        }

        [Test]
        public async Task TestNoCommit()
        {
            var unitOfWork = new UnitOfWork(_dataContext, CreateOperation, ReadOperation, UpdateOperation, DeleteOperation);
            
            var testEntity = new TestEntity {
                TestPropertyInt = 10,
                TestPropertyString = "10" 
            };

            var dbEntity = await ReadOperation.Find(testEntity);
            Assert.IsNull(dbEntity);

            var newEntity = await CreateOperation.Create(testEntity);
            AssertCompare(newEntity, testEntity);
            
            dbEntity = await ReadOperation.Find(testEntity);
            Assert.IsNull(dbEntity);

            testEntity.TestPropertyInt = 11;
            testEntity.TestPropertyString = "11";
            var updatedEntity = await UpdateOperation.Update(testEntity);
            AssertCompare(updatedEntity, testEntity);
       
            dbEntity = await ReadOperation.Find(testEntity);
            Assert.IsNull(dbEntity);

            var isDeleted = await DeleteOperation.Delete(testEntity);
            Assert.IsTrue(isDeleted);

            dbEntity = await ReadOperation.Find(testEntity);
            Assert.IsNull(dbEntity);
        }

        [Test]
        public async Task TestCommit()
        {
            var unitOfWork = new UnitOfWork(_dataContext, CreateOperation, ReadOperation, UpdateOperation, DeleteOperation);

            var testEntity = new TestEntity
            {
                TestPropertyInt = 10,
                TestPropertyString = "10"
            };

            var dbEntity = await ReadOperation.Find(testEntity);
            Assert.IsNull(dbEntity);

            var newEntity = await CreateOperation.Create(testEntity);
            AssertCompare(testEntity, newEntity);

            await unitOfWork.Commit();

            dbEntity = await ReadOperation.Find(testEntity);
            Assert.IsNotNull(dbEntity);
            AssertCompare(newEntity, dbEntity);

            testEntity.TestPropertyInt = 11;
            testEntity.TestPropertyString = "11";
            var updatedEntity = await UpdateOperation.Update(testEntity);

            await unitOfWork.Commit();

            AssertCompare(updatedEntity, testEntity);

            dbEntity = await ReadOperation.Find(testEntity);
            Assert.IsNotNull(dbEntity);
            AssertCompare(updatedEntity, dbEntity);

            var isDeleted = await DeleteOperation.Delete(testEntity);
            Assert.IsTrue(isDeleted);

            await unitOfWork.Commit();

            dbEntity = await ReadOperation.Find(testEntity);
            Assert.IsNull(dbEntity);
        }

        [Test]
        public async Task TestRollback()
        {
            var predicateProviderFactory = new PredicateProviderFactory();
            var predicateFactory = new PredicateFactory(predicateProviderFactory);
            ReadOperation = new ReadTrackingOperation(_dataContext, predicateFactory);
            var unitOfWork = new UnitOfWork(_dataContext, CreateOperation, ReadOperation, UpdateOperation, DeleteOperation);

            var testEntity = new TestEntity
            {
                TestPropertyInt = 10,
                TestPropertyString = "10"
            };

            var dbEntity = await ReadOperation.Find(testEntity);
            Assert.IsNull(dbEntity);

            //create and rollback
            var newEntity = await CreateOperation.Create(testEntity);
            AssertCompare(newEntity, testEntity);
            dbEntity = GetTrackedEntity(testEntity);
            Assert.IsNotNull(dbEntity);

            await unitOfWork.Rollback();
            dbEntity = await CheckDoesEntityNotExist(testEntity);

            //create, update and rollback
            newEntity = await CreateOperation.Create(testEntity);
            AssertCompare(newEntity, testEntity);
            dbEntity = await CheckDoesEntityExist(testEntity);

            testEntity.TestPropertyInt = 11;
            testEntity.TestPropertyString = "11";
            var updatedEntity = await UpdateOperation.Update(testEntity);
            AssertCompare(updatedEntity, testEntity);

            dbEntity = GetTrackedEntity(testEntity);
            Assert.IsNotNull(dbEntity);
            AssertCompare(dbEntity, updatedEntity);

            await unitOfWork.Rollback();
            dbEntity = await CheckDoesEntityNotExist(testEntity);

            //create, delete and rollback
            newEntity = await CreateOperation.Create(testEntity);
            AssertCompare(newEntity, testEntity);
            dbEntity = await CheckDoesEntityExist(testEntity);

            var isDeleted = await DeleteOperation.Delete(testEntity);
            Assert.IsTrue(isDeleted);
            dbEntity = await CheckDoesEntityExist(testEntity);

            await unitOfWork.Rollback();
            dbEntity = await CheckDoesEntityNotExist(testEntity);
        }

        private async Task<TestEntity> CheckDoesEntityExist(TestEntity testEntity)
        {
            TestEntity dbEntity = GetTrackedEntity(testEntity);
            Assert.IsNotNull(dbEntity);
            dbEntity = await ReadOperation.Find(testEntity);
            Assert.IsNull(dbEntity);
            return dbEntity;
        }

        private async Task<TestEntity> CheckDoesEntityNotExist(TestEntity testEntity)
        {
            TestEntity dbEntity = GetTrackedEntity(testEntity);
            Assert.IsNull(dbEntity);
            dbEntity = await ReadOperation.Find(testEntity);
            Assert.IsNull(dbEntity);
            return dbEntity;
        }

        private TestEntity GetTrackedEntity(TestEntity testEntity)
        {
            return _dataContext.ChangeTracker.Entries()
                .Where(x => x.State != Microsoft.EntityFrameworkCore.EntityState.Unchanged && x.Entity is TestEntity)
                .Select(x => x.Entity as TestEntity)
                .SingleOrDefault(x => x.TestPropertyInt == testEntity.TestPropertyInt && x.TestPropertyString == testEntity.TestPropertyString);
        }

        private static void AssertCompare(TestEntity testEntity, TestEntity newEntity)
        {
            Assert.IsTrue(newEntity.TestPropertyInt == testEntity.TestPropertyInt && newEntity.TestPropertyString == testEntity.TestPropertyString);
        }
    }
}
