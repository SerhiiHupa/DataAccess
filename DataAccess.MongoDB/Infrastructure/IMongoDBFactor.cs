using MongoDB.Driver;

namespace DataAccess.MongoDB.Infrastructure
{
    public interface IMongoDBFactory
    {
        IMongoDatabase Get();
    }
}