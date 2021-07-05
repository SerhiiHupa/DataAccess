using System.Threading.Tasks;

namespace DataAccess.Interfaces.Identifier
{
    public interface IIdentifierDeleteOperation<T> where T : class, IIdentifier
    {
        Task<bool> Delete(IIdentifier identifier);
    }
}
