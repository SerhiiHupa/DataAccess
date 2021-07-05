using System.Collections.Generic;
using System.Linq;
using DataAccess.Models;
using DataAccess.MongoDB.CRUD;
using DataAccess.MongoDB.Infrastructure;
using DataAccess.PredicateInfrastructure;
using DataAccess.Unified.IntegrationTests;
using NUnit.Framework;

namespace DataAccess.MongoDB.IntegrationTests
{
    public static class SetUpHelper
    {
        public static void SetUp(CRUDOperations operations)
        {
            var nameOfCollection = typeof(TestEntity).Name;
            var mondoClientFactory = new MongoClientFactory();
            var databaseFactory = new MongoDBFactory(mondoClientFactory);

            var database = databaseFactory.Get();
            var dbClient = mondoClientFactory.Get();

            var collection = database.GetCollection<TestEntity>(nameOfCollection);
            if (collection == null)
            {
                database.CreateCollection(nameOfCollection);
                collection = database.GetCollection<TestEntity>(nameOfCollection);
            }

            var collectionData = new List<TestEntity>() {
                new TestEntity { TestPropertyInt = 1, TestPropertyString = "1" },
                new TestEntity { TestPropertyInt = 2, TestPropertyString = "2" },
                new TestEntity { TestPropertyInt = 2, TestPropertyString = "2" },
                new TestEntity { TestPropertyInt = 3, TestPropertyString = "3" },
            };

            collection.InsertMany(collectionData);

            var predicateProviderFactory = new PredicateProviderFactory();
            var predicateFactory = new PredicateFactory(predicateProviderFactory);
            operations.ReadOperation = new ReadOperation(databaseFactory, predicateFactory);
            operations.CreateOperation = new CreateOperation(databaseFactory, predicateFactory);
            operations.UpdateOperation = new UpdateOperation(databaseFactory, predicateFactory);
            operations.DeleteOperation = new DeleteOperation(databaseFactory, predicateFactory);
        }
    }
}
