using System.Threading.Tasks;
using DataAccess.Interfaces.Identifier;

namespace DataAccess.Interfaces.CRUD
{
    public interface ICreateOperation
    {
        Task<T> Create<T>(T entity) where T : class, IIdentifier;
    }
}
