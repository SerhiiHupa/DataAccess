using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using DataAccess.Interfaces;
using DataAccess.Interfaces.CRUD;

namespace DataAccess
{
    // public abstract class ReadOperationBase: IReadOperation
    // {
    //     private IPredicateProvider _predicateProvider;

    //     protected ReadOperationBase(IPredicateProvider predicateProvider)
    //     {
    //         _predicateProvider = predicateProvider;
    //     }

    //     public async Task<T> Find<T>(T entity) where T : class
    //     {
    //         var predicate = _predicateProvider.Get<T>(entity);
    //         return await Find(predicate);
    //     }

    //     public abstract Task<T> Find<T>(Expression<Func<T, bool>> predicate) where T : class;

    //     public abstract Task<IEnumerable<T>> FindAll<T>(Expression<Func<T, bool>> predicate) where T : class;
    // }
}
