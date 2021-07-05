using System.Threading.Tasks;
using DataAccess.Interfaces.CRUD;
using DataAccess.Interfaces.Identifier;
using DataAccess.MongoDB.Infrastructure;
using DataAccess.PredicateInfrastructure;
using MongoDB.Driver;

namespace DataAccess.MongoDB.CRUD
{
    public class UpdateOperation : BaseOperation, IUpdateOperation
    {
        public UpdateOperation(IMongoDBFactory mongoDBFactory, IPredicateFactory predicateFactory) : 
            base(mongoDBFactory, predicateFactory)
        {
        }

        public async Task<T> Update<T>(T entity) where T : class, IIdentifier
        {
            await GetCollection<T>().ReplaceOneAsync(x => x.Id == entity.Id, entity);

            return entity;
        }
    }
}
