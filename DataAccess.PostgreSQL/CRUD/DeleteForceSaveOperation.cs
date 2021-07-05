using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using DataAccess.Interfaces.Identifier;
using DataAccess.PostgreSQL.Infrastructure;
using DataAccess.PredicateInfrastructure;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.PostgreSQL.CRUD
{
    public class DeleteForceSaveOperation : DeleteOperation
    {

        public DeleteForceSaveOperation(DataContext dataContext, IPredicateFactory predicateFactory) : 
            base(dataContext, predicateFactory)
        {
        }

        public override async Task<bool> DeleteById<T>(IIdentifier identifier) where T : class
        {
            var result = await base.DeleteById<T>(identifier);

            await DataContext.SaveChangesAsync();

            return true;
        }

        public override async Task<bool> Delete<T>(T entity) where T : class
        {
            var result = await base.Delete(entity);

            await DataContext.SaveChangesAsync();

            return result;
        }

        public override async Task<bool> Delete<T>(Expression<Func<T, bool>> predicate) where T : class
        {
            var result = await base.Delete(predicate);

            await DataContext.SaveChangesAsync();

            return result;
        }

        public override async Task<bool> DeleteAll<T>() where T : class
        {
            var tableName = DataContext.Set<T>().EntityType.GetTableName();
            var result = await DataContext.Database.ExecuteSqlRawAsync($"TRUNCATE TABLE \"{tableName}\"");

            return Convert.ToBoolean(result);
        }
    }
}
