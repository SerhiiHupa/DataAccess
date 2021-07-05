using System;
using System.Linq.Expressions;

namespace DataAccess.PredicateInfrastructure
{
    public interface IPredicateFactory
    {
        Expression<Func<T, bool>> Get<T>(T entity) where T : class;
    }
}