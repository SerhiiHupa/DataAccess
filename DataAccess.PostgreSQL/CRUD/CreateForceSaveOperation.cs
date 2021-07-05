using System.Threading.Tasks;
using DataAccess.PostgreSQL.Infrastructure;
using DataAccess.PredicateInfrastructure;

namespace DataAccess.PostgreSQL.CRUD
{
    public class CreateForceSaveOperation : CreateOperation
    {
        public CreateForceSaveOperation(DataContext dataContext, IPredicateFactory predicateFactory) : base(dataContext, predicateFactory)
        {
        }

        public override async Task<T> Create<T>(T entity) where T : class
        {
            var result = await base.Create(entity);

            await DataContext.SaveChangesAsync();

            return result;
        }
    }
}
