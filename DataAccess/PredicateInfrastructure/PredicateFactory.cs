using System;
using System.Linq.Expressions;

namespace DataAccess.PredicateInfrastructure
{
    public class PredicateFactory : IPredicateFactory
    {
        private IPredicateProviderFactory _predicateProviderFactory;

        public PredicateFactory(IPredicateProviderFactory predicateProviderFactory)
        {
            _predicateProviderFactory = predicateProviderFactory;
        }

        public Expression<Func<T, bool>> Get<T>(T entity) where T : class
        {
            var predicateProvider = _predicateProviderFactory.Get<T>();
            var predicate = predicateProvider.Get(entity);

            return predicate;
        }
    }
}