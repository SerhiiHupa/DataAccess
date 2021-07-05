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
    public class ReadOperation : IReadOperation
    {
        private readonly DataContext _dataContext;
        private readonly IPredicateFactory _predicateFactory;

        public ReadOperation(DataContext dataContext, IPredicateFactory predicateFactory)
        {
            _dataContext = dataContext;
            _predicateFactory = predicateFactory;
        }

        public async Task<T> Find<T>(T entity) where T : class
        {
            var predicate = _predicateFactory.Get<T>(entity);
            var result = await Find(predicate);

            return result;
        }

        public async Task<T> Find<T>(Expression<Func<T, bool>> predicate) where T : class
        {
            var result = await _dataContext.Set<T>().SingleOrDefaultAsync(predicate);

            return result;
        }

        public async Task<IEnumerable<T>> FindAll<T>(T entity) where T : class
        {
            var predicate = _predicateFactory.Get<T>(entity);
            var result = await FindAll(predicate);

            return result;
        }

        public async Task<IEnumerable<T>> FindAll<T>(Expression<Func<T, bool>> predicate) where T : class
        {
            var result = await _dataContext.Set<T>().Where(predicate).ToListAsync();

            return result;
        }

        public async Task<T> FindById<T>(IIdentifier identifier) where T : class, IIdentifier
        {
            var result = await _dataContext.Set<T>().SingleOrDefaultAsync(x => x.Id == identifier.Id);

            return result;
        }
    }
}
