using MongoDB.Driver;

namespace DataAccess.MongoDB.Infrastructure
{
    public interface IMongoClientFactory
    {
        IMongoClient Get();
    }
}