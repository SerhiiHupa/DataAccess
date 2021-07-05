using System;
using MongoDB.Driver;

namespace DataAccess.MongoDB.Infrastructure
{

    public class MongoClientFactory : IMongoClientFactory
    {
        public IMongoClient Get()
        {
            var settings = MongoClientSettings.FromConnectionString("mongodb+srv://admin:WELCOME642311@cluster0.qwqdn.mongodb.net/myFirstDatabase?retryWrites=true&w=majority");
            // var settings = MongoClientSettings.FromConnectionString("mongodb://localhost:27017");
            var dbClient = new MongoClient(settings);

            return dbClient;
        }
    }
}