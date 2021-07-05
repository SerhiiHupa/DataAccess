using System.Threading.Tasks;
using DataAccess.Interfaces.CRUD;
using DataAccess.PostgreSQL.Infrastructure;

namespace DataAccess
{
    public class UnitOfWork : IUnitOfWork
    {
        private DataContext _dataContext;

        public UnitOfWork(
            DataContext dataContext, 
            ICreateOperation createOperation, 
            IReadOperation readOperation, 
            IUpdateOperation updateOperation, 
            IDeleteOperation deleteOperation)
        {
            _dataContext = dataContext;
            CreateOperation = createOperation;
            ReadOperation = readOperation;
            UpdateOperation = updateOperation;
            DeleteOperation = deleteOperation;
        }

        public ICreateOperation CreateOperation { get; set; }

        public IReadOperation ReadOperation { get; set; }

        public IUpdateOperation UpdateOperation { get; set; }

        public IDeleteOperation DeleteOperation { get; set; }

        public async Task<bool> Commit() {
            await _dataContext.SaveChangesAsync();

            return true;
        }

        public async Task<bool> Rollback() {
            _dataContext.Rollback();

            return await Task.FromResult(true);
        }
    }
}
