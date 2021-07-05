using System;
using System.Collections.Generic;
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
    public class ReadTrackingOperation : ReadOperationBase, IReadOperation
    {
        public ReadTrackingOperation(DataContext dataContext, IPredicateFactory predicateFactory) : 
            base(dataContext, predicateFactory)
        {
        }

        public async Task<T> Find<T>(T entity) where T : class
        {
            var predicate = PredicateFactory.Get<T>(entity);
            var result = await Find(predicate);

            return result;
        }

        public async Task<T> Find<T>(Expression<Func<T, bool>> predicate) where T : class
        {
            var result = await GetSet<T>().SingleOrDefaultAsync(predicate);

            return result;
        }

        public async Task<IEnumerable<T>> FindAll<T>(T entity) where T : class
        {
            var predicate = PredicateFactory.Get<T>(entity);
            var result = await FindAll(predicate);

            return result;
        }

        public async Task<IEnumerable<T>> FindAll<T>(Expression<Func<T, bool>> predicate) where T : class
        {
            var result = await GetSet<T>().Where(predicate).ToListAsync();

            return result;
        }

        public async Task<T> FindById<T>(IIdentifier identifier) where T : class, IIdentifier
        {
            var result = await GetSet<T>().SingleOrDefaultAsync(x => x.Id == identifier.Id);

            return result;
        }
    }
}
