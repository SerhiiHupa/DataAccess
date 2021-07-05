using System.Threading.Tasks;
using DataAccess.Interfaces.Identifier;

namespace DataAccess.Interfaces.CRUD
{
    public interface IUpdateOperation
    {
        Task<T> Update<T>(T entity) where T : class, IIdentifier;
    }
}
