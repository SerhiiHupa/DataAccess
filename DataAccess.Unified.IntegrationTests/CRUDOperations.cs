using DataAccess.Interfaces.CRUD;

namespace DataAccess.Unified.IntegrationTests
{
    public class CRUDOperations
    {
        public ICreateOperation CreateOperation {get; set;}
        public IReadOperation ReadOperation {get;set;}
        public IUpdateOperation UpdateOperation {get; set;}
        public IDeleteOperation DeleteOperation {get; set;}
    }
}
