using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using DataAccess.Interfaces.Identifier;

namespace DataAccess.Interfaces.CRUD
{
    public interface IReadOperation
    {
        Task<T> FindById<T>(IIdentifier id) where T: class, IIdentifier;
        Task<T> Find<T>(T entity) where T : class;
        Task<IEnumerable<T>> FindAll<T>(T entity) where T : class;
        Task<T> Find<T>(Expression<Func<T, bool>> predicate) where T : class;
        Task<IEnumerable<T>> FindAll<T>(Expression<Func<T, bool>> predicate) where T : class;
    }
}
