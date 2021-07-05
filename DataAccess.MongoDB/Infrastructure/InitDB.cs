using System;
using MongoDB.Driver;

namespace DataAccess.MongoDB.Infrastructure
{
    public class InitDB
    {
        public void Init()
        {
            var settings = MongoClientSettings.FromConnectionString("mongodb+srv://admin:WELCOME642311@cluster0.qwqdn.mongodb.net/myFirstDatabase?retryWrites=true&w=majority");
            var dbClient = new MongoClient(settings);
            var database = dbClient.GetDatabase("test");

            var dbList = dbClient.ListDatabases().ToList();

            Console.WriteLine("The list of databases on this server is: ");
            foreach (var db in dbList)
            {
                Console.WriteLine(db);
            }
        }
    }
}
