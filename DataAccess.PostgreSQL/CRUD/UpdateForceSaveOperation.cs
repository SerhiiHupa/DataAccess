using System.Threading.Tasks;
using DataAccess.PostgreSQL.Infrastructure;
using DataAccess.PredicateInfrastructure;

namespace DataAccess.PostgreSQL.CRUD
{
    public class UpdateForceSaveOperation : UpdateOperation
    {

        public UpdateForceSaveOperation(DataContext dataContext, IPredicateFactory predicateFactory) : base(dataContext, predicateFactory)
        {
        }
        
        public override async Task<T> Update<T>(T entity) where T : class
        {
            var result = await base.Update(entity);

            await DataContext.SaveChangesAsync();

            return result;
        }
    }
}
