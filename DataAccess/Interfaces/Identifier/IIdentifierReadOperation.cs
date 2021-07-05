using System.Threading.Tasks;

namespace DataAccess.Interfaces.Identifier
{
    public interface IIdentifierReadOperation<T> where T : class, IIdentifier
    {
        Task<T> Find(IIdentifier identifier);
    }
}
