using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using DataAccess.Interfaces.CRUD;
using DataAccess.Interfaces.Identifier;
using DataAccess.MongoDB.Infrastructure;
using DataAccess.PredicateInfrastructure;

namespace DataAccess.MongoDB.CRUD
{
    public class DeleteOperation : BaseOperation, IDeleteOperation
    {
        public DeleteOperation(IMongoDBFactory mongoDBFactory, IPredicateFactory predicateFactory) : 
            base(mongoDBFactory, predicateFactory)
        {
        }

        public async Task<bool> Delete<T>(T entity) where T : class
        {
            var predicate = _predicateFactory.Get<T>(entity);
            var result = await Delete<T>(predicate);

            return result;
        }

        public async Task<bool> Delete<T>(Expression<Func<T, bool>> predicate) where T : class
        {
            var result = await GetCollection<T>().DeleteManyAsync(predicate);
            return result.IsAcknowledged;
        }

        public async Task<bool> DeleteAll<T>() where T : class
        {
            var result = await Delete<T>(x => true);
            return result;
        }

        public async Task<bool> DeleteById<T>(IIdentifier identifier) where T : class, IIdentifier
        {
            var result = await Delete<T>(x => x.Id == identifier.Id);
            return result;
        }
    }
}
