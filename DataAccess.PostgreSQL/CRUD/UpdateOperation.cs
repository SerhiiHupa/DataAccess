using System.Threading.Tasks;
using DataAccess.Interfaces.CRUD;
using DataAccess.Interfaces.Identifier;
using DataAccess.PostgreSQL.Infrastructure;
using DataAccess.PredicateInfrastructure;

namespace DataAccess.PostgreSQL.CRUD
{
    public class UpdateOperation : IUpdateOperation
    {
        protected DataContext DataContext {get;}

        public UpdateOperation(DataContext dataContext, IPredicateFactory predicateFactory)
        {
            DataContext = dataContext;
        }
        
        public virtual async Task<T> Update<T>(T entity) where T : class, IIdentifier
        {
            DataContext.Update(entity);

            return await Task.FromResult(entity);
        }
    }
}
