using System;
using System.Linq.Expressions;

namespace DataAccess.PredicateInfrastructure
{

    public interface IPredicateProvider<T>
    {
        Expression<Func<T, bool>> Get(T entity);
    }
}