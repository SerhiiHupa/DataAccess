using System.Threading.Tasks;
using DataAccess.Interfaces.CRUD;
using DataAccess.Interfaces.Identifier;
using DataAccess.MongoDB.Infrastructure;
using DataAccess.PredicateInfrastructure;

namespace DataAccess.MongoDB.CRUD
{
    public class CreateOperation : BaseOperation, ICreateOperation
    {

        public CreateOperation(IMongoDBFactory mongoDBFactory, IPredicateFactory predicateFactory) :
            base(mongoDBFactory, predicateFactory)
        {
        }

        public async Task<T> Create<T>(T entity) where T : class, IIdentifier
        {
            await GetCollection<T>().InsertOneAsync(entity);

            return entity;
        }
    }
}
