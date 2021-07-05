using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using DataAccess.Interfaces.CRUD;
using DataAccess.Interfaces.Identifier;
using DataAccess.PostgreSQL.Infrastructure;
using DataAccess.PredicateInfrastructure;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.PostgreSQL.CRUD
{
    public class DeleteOperation : IDeleteOperation
    {
        protected DataContext DataContext { get; }
        private readonly IPredicateFactory _predicateFactory;

        public DeleteOperation(DataContext dataContext, IPredicateFactory predicateFactory)
        {
            DataContext = dataContext;
            _predicateFactory = predicateFactory;
        }

        public virtual async Task<bool> DeleteById<T>(IIdentifier identifier) where T : class, IIdentifier
        {
            var dbEntity = await DataContext.Set<T>().SingleOrDefaultAsync(x => x.Id == identifier.Id);
            if (dbEntity == null)
            {
                return true;
            }

            DataContext.Remove(dbEntity);

            return true;
        }

        public virtual async Task<bool> Delete<T>(T entity) where T : class
        {
            var predicate = _predicateFactory.Get<T>(entity);
            var result = await Delete(predicate);

            return result;
        }

        public virtual async Task<bool> Delete<T>(Expression<Func<T, bool>> predicate) where T : class
        {
            var dbEntity = DataContext.Set<T>().Where(predicate);

            if (dbEntity == null || !dbEntity.Any())
            {
                return true;
            }

            DataContext.RemoveRange(dbEntity);

            return await Task.FromResult(true);
        }

        //note: we can't delete all records with SQL query here
        //because we can't make any change in th DB due to UnitOfWork
        //as a workaround we can use very slow operation with the context
        public virtual Task<bool> DeleteAll<T>() where T : class
        {
            throw new NotImplementedException();
        }
    }
}
