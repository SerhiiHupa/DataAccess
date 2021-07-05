using System.Linq;
using DataAccess.PostgreSQL.Infrastructure;
using DataAccess.PredicateInfrastructure;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.PostgreSQL.CRUD
{
    public abstract class ReadOperationBase
    {
        protected readonly DataContext DataContext;
        protected readonly IPredicateFactory PredicateFactory;

        public ReadOperationBase(DataContext dataContext, IPredicateFactory predicateFactory)
        {
            DataContext = dataContext;
            PredicateFactory = predicateFactory;
        }

        public DbSet<T> GetSet<T>() where T : class
        {
            return DataContext.Set<T>();;
        }

        public IQueryable<T> GetNoTrackingSet<T>() where T : class
        {
            return DataContext.Set<T>().AsNoTracking();
        }
    }
}
