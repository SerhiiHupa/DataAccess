using System.Collections.Generic;
using DataAccess.Models;
using DataAccess.PostgreSQL.CRUD;
using DataAccess.PostgreSQL.Infrastructure;
using DataAccess.PredicateInfrastructure;
using DataAccess.Unified.IntegrationTests;

namespace DataAccess.PostgreSQL.IntegrationTests
{
    public static class SetUpHelper
    {
        public static void SetUp(CRUDOperations operations)
        {
            var context = new DataContext();
            context.RemoveRange(context.Set<TestEntity>());
            context.SaveChanges();

            var predicateProviderFactory = new PredicateProviderFactory();
            var predicateFactory = new PredicateFactory(predicateProviderFactory);

            operations.CreateOperation = new CreateForceSaveOperation(new DataContext(), predicateFactory);
            operations.ReadOperation = new ReadNoTrackingOperation(new DataContext(), predicateFactory);
            operations.UpdateOperation = new UpdateForceSaveOperation(new DataContext(), predicateFactory);
            operations.DeleteOperation = new DeleteForceSaveOperation(new DataContext(), predicateFactory);

            var testEntitiesData = new List<TestEntity>() {
                new TestEntity { TestPropertyInt = 1, TestPropertyString = "1" },
                new TestEntity { TestPropertyInt = 2, TestPropertyString = "2" },
                new TestEntity { TestPropertyInt = 2, TestPropertyString = "2" },
                new TestEntity { TestPropertyInt = 3, TestPropertyString = "3" },
            };

            context.AddRange(testEntitiesData);
            context.SaveChanges();
        }

        public static void SetUpWithoutForceSave(CRUDOperations operations, DataContext context)
        {
            context.RemoveRange(context.Set<TestEntity>());
            context.SaveChanges();

            var predicateProviderFactory = new PredicateProviderFactory();
            var predicateFactory = new PredicateFactory(predicateProviderFactory);

            operations.CreateOperation = new CreateOperation(context, predicateFactory);
            operations.ReadOperation = new ReadNoTrackingOperation(context, predicateFactory);
            operations.UpdateOperation = new UpdateOperation(context, predicateFactory);
            operations.DeleteOperation = new DeleteOperation(context, predicateFactory);

            var testEntitiesData = new List<TestEntity>() {
                new TestEntity { TestPropertyInt = 1, TestPropertyString = "1" },
                new TestEntity { TestPropertyInt = 2, TestPropertyString = "2" },
                new TestEntity { TestPropertyInt = 2, TestPropertyString = "2" },
                new TestEntity { TestPropertyInt = 3, TestPropertyString = "3" },
            };

            context.AddRange(testEntitiesData);
            context.SaveChanges();
        }
    }
}
