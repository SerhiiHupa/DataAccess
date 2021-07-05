using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using DataAccess.Interfaces.Identifier;

namespace DataAccess.Interfaces.CRUD
{

    public interface IDeleteOperation
    {
        Task<bool> DeleteById<T>(IIdentifier identifier) where T : class, IIdentifier;
        Task<bool> Delete<T>(T entity) where T : class;
        Task<bool> Delete<T>(Expression<Func<T, bool>> predicate) where T : class;
        Task<bool> DeleteAll<T>() where T : class;
        
    }
}
