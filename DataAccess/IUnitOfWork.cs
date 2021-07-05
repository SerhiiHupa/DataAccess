using System.Threading.Tasks;
using DataAccess.Interfaces.CRUD;

namespace DataAccess
{
    public interface IUnitOfWork
    {
        ICreateOperation CreateOperation { get; set; }

        IReadOperation ReadOperation { get; set; }

        IUpdateOperation UpdateOperation { get; set; }

        IDeleteOperation DeleteOperation { get; set; }

        Task<bool> Commit();

        Task<bool> Rollback();
    }
}
