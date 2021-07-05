using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using DataAccess.Interfaces.CRUD;
using DataAccess.Interfaces.Identifier;
using DataAccess.MongoDB.Infrastructure;
using DataAccess.PredicateInfrastructure;
using MongoDB.Driver;

namespace DataAccess.MongoDB.CRUD
{
    public class ReadOperation : BaseOperation, IReadOperation
    {
        public ReadOperation(IMongoDBFactory mongoDBFactory, IPredicateFactory predicateFactory) : 
            base(mongoDBFactory, predicateFactory)
        {
        }

        public async Task<T> FindById<T>(IIdentifier identifier) where T : class, IIdentifier
        {
            var result = await Find<T>(x => x.Id == identifier.Id);
            return result;
        }

        public async Task<T> Find<T>(T entity) where T : class
        {
            var result = await FindAsync<T>(entity);
            return await result.SingleOrDefaultAsync();;
        }

        public async Task<IEnumerable<T>> FindAll<T>(T entity) where T : class
        {
            var result = await FindAsync<T>(entity);
            return result.ToList();
        }

        public async Task<T> Find<T>(Expression<Func<T, bool>> predicate) where T : class
        {
            var asyncCursor = await FindAsync(predicate);
            var result = asyncCursor.SingleOrDefault<T>();

            return result;
        }

        public async Task<IEnumerable<T>> FindAll<T>(Expression<Func<T, bool>> predicate) where T : class
        {
            var asyncCursor = await FindAsync(predicate);
            var result = asyncCursor.ToEnumerable<T>();

            return result;
        }
    }
}
