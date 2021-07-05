using System.Threading.Tasks;
using DataAccess.Interfaces.CRUD;
using DataAccess.Interfaces.Identifier;
using DataAccess.PostgreSQL.Infrastructure;
using DataAccess.PredicateInfrastructure;

namespace DataAccess.PostgreSQL.CRUD
{
    public class CreateOperation : ICreateOperation
    {
        protected DataContext DataContext { get; }

        public CreateOperation(DataContext dataContext, IPredicateFactory predicateFactory)
        {
             DataContext = dataContext;
        }

        public virtual async Task<T> Create<T>(T entity) where T : class, IIdentifier
        {
            DataContext.Add(entity);

            return await Task.FromResult(entity);
        }
    }
}
