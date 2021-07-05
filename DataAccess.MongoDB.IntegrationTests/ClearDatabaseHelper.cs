using MongoDB.Driver;
using DataAccess.Models;
using DataAccess.MongoDB.Infrastructure;

namespace DataAccess.MongoDB.IntegrationTests
{
    public static class ClearDatabaseHelper
    {
        public static void Clear()
        {
            var mondoClientFactory = new MongoClientFactory();
            var mongoDBFactory = new MongoDBFactory(mondoClientFactory);

            mongoDBFactory
                .Get()
                .GetCollection<TestEntity>(nameof(TestEntity))
                .DeleteMany<TestEntity>(x => true);
        }
    }
}
