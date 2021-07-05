using System;
using MongoDB.Driver;

namespace DataAccess.MongoDB.Infrastructure
{

    public class MongoDBFactory : IMongoDBFactory
    {
        private IMongoClientFactory _mongoClientFactory;

        public MongoDBFactory(IMongoClientFactory mongoClientFactory)
        {
            _mongoClientFactory = mongoClientFactory;
        }

        public IMongoDatabase Get()
        {
            var settings = MongoClientSettings.FromConnectionString();
            var dbClient = new MongoClient(settings);

            return _mongoClientFactory.Get().GetDatabase("test");
        }
    }
}