using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using DataAccess.MongoDB.Infrastructure;
using DataAccess.PredicateInfrastructure;
using MongoDB.Driver;

namespace DataAccess.MongoDB.CRUD
{
    public abstract class BaseOperation
    {
        protected readonly IPredicateFactory _predicateFactory;
        private readonly IMongoDatabase _database;

        protected BaseOperation(IMongoDBFactory mongoDBFactory, IPredicateFactory predicateFactory)
        {
            _predicateFactory = predicateFactory;
            _database = mongoDBFactory.Get();
        }

        protected IMongoCollection<T> GetCollection<T>()
        {
            return _database.GetCollection<T>(typeof(T).Name);
        }

        protected async Task<IAsyncCursor<T>> FindAsync<T>(T entity) where T : class
        {
            var predicate = _predicateFactory.Get<T>(entity);
            return await GetCollection<T>().FindAsync(predicate);
        }

        protected async Task<IAsyncCursor<T>> FindAsync<T>(Expression<Func<T, bool>> predicate) where T : class
        {
            return await GetCollection<T>().FindAsync(predicate);
        }
    }
}
